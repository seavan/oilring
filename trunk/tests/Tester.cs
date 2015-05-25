using Microsoft.Practices.Unity;
using Notamedia.Oilring.Database;
using System.Web.Configuration;
using Notamedia.Oilring.Community;
using admin.db;
using System.Web.Mvc;
using System.Configuration;
using System.Linq;
using System.Collections.Generic;
using Notamedia.Oilring.Database.DataAccess;
using System;
using System.Net.Mail;
using System.IO;
using Sphinx.Client.Connections;
using Sphinx.Client.Commands.Search;
using System.Globalization;
using Sphinx.Client.Commands.BuildExcerpts;
using Microsoft.Security.Application;
using System.Data.Linq;
using Database.Entities;
using Database.Interfaces;
using Database.Implementation;
using Database;
using Common.IoC;
using Common.ContentProcessing;

namespace tests
{
    public class Tester
    {
        public Tester()
        {
            ConfigureUnity();
        }

        private IDataServiceLocator m_DataStore;
        private TraceDataContext m_DataContext;

        public static string IMPORT_IMAGE_DIR = "input_images";
        public static string IMPORT_USER_IMAGE_DIR = "input_user_images";
        public static string OUTPUT_IMAGE_DIR = "output_images";
        public static string REMOTE_IMAGE_DIR = @"\\win.office.notamedia.ru\images";
        public static string LOCAL_IMAGE_DIR = @"D:\Projects\oilring\trunk\oilring\Content\images";

        private void ConfigureUnity()
        {
            //Create UnityContainer          
            IUnityContainer result = new UnityContainer();
            result
                // контекст данных со временем жизни в рамках http-запроса
                //            .RegisterType<OilringContext>("Context", new HttpContextLifetimeManager<OilringContext>(),
                //                                                  new InjectionConstructor(WebConfigurationManager.ConnectionStrings["Oilring"].ConnectionString))
                //            .RegisterType<MailDataContext>("MailContext", new HttpContextLifetimeManager<MailDataContext>(),
                //                                                    new InjectionConstructor(WebConfigurationManager.ConnectionStrings["Mail"].ConnectionString))

//            .RegisterType<VideoContext, VideoContext>("VideoContext", new HttpContextLifetimeManager<MailDataContext>(), new InjectionConstructor(ConfigurationManager.ConnectionStrings["Video"].ConnectionString))

                .RegisterInstance<IDataStore>(new DataStore());

            result
                .RegisterInstance<TraceDataContext>("WebTraceContext", new WebTraceContext(ConfigurationManager.ConnectionStrings["Oilring"].ConnectionString));


            MvcUnityContainer.Container = result;

            //var ds = result.Resolve<OilringTraceContext>("WebTraceContext");
            m_DataStore = result.Resolve<IDataServiceLocator>();
            m_DataContext = result.Resolve<TraceDataContext>("WebTraceContext");

            m_DataStore.PhotoService.SetTargetDirectories(
                new string[] { OUTPUT_IMAGE_DIR, REMOTE_IMAGE_DIR, LOCAL_IMAGE_DIR });
            //Set Controller Factory as UnityControllerFactory
            ControllerBuilder.Current.SetControllerFactory(typeof(CommunityControllerFactory));
        }

        public void SphinxTester()
        {
            // Create persistent TCP connection object to Sphinx
            using (ConnectionBase connection = new PersistentTcpConnection("localhost", 9312))
            {
                //                Console.OutputEncoding = Enco
                Console.WriteLine("Enter query");
                var q = Console.ReadLine();
                // Create new search query object and pass query text as argument
                SearchQuery searchQuery = new SearchQuery(q);

                // Set match mode to SPH_MATCH_EXTENDED2
                searchQuery.MatchMode = MatchMode.Extended2;
                // Add Sphinx index name to list
                searchQuery.Indexes.Add("articles");
                // Setup attribute filter
                //DateTime[] datesToExclude = new DateTime[] { DateTime.ParseExact("2005-05-05 20:07:09", "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture) };

                //searchQuery.AttributeFilters.Add("ObjectType", 0, true);
                // Set amount of matches will be returned to client 
                searchQuery.Limit = 5000;

                // Create search command object
                SearchCommand searchCommand = new SearchCommand(connection);
                // Add newly created search query object to query list
                searchCommand.QueryList.Add(searchQuery);
                // Execute command on server and obtain results
                searchCommand.Execute();

                if (searchCommand.Result.QueryResults.Count == 0)
                {
                    Console.WriteLine("No results");
                    return;
                }

                var entities = CreateSelector().AllEntities();


                // Print results
                List<IFullTextSearchable> m_Results = new List<IFullTextSearchable>();

                foreach (SearchQueryResult result in searchCommand.Result.QueryResults)
                {
                    foreach (Match match in result.Matches)
                    {
                        Console.WriteLine("Document ID: {0}", match.DocumentId);
                        Console.WriteLine("Weight: {0}", match.Weight);

                        var id = match.DocumentId;
                        var otype = match.AttributesValues["objecttype"].GetValue().ToString().Trim();// match.AttributesValues["ObjectType"].GetValue().ToString();

                        var obj = entities.Single(s => s.Id.Equals(id) && s.ObjectType.Equals(otype));
                        var iobj = obj as IFullTextSearchable;
                        m_Results.Add(iobj);

                        //Console.WriteLine("Attribute 'date_added' value: {0}", match.AttributesValues["date_added"].GetValue());
                    }

                    Console.WriteLine("Elapsed time: {0} ms", result.ElapsedTime.TotalMilliseconds);
                    Console.WriteLine("Total found: {0}", result.TotalFound);
                    Console.WriteLine("Returned matches count: {0}", result.Count);
                }

                Console.WriteLine("Excerpts:");
                var excerptsCommand = new BuildExcerptsCommand(connection);
                excerptsCommand.Documents.AddRange(m_Results.Select(s => s.ShortDescription).Union(m_Results.Select(s => s.Title)));
                excerptsCommand.Keywords.Add(q);
                excerptsCommand.Index = "base";
                excerptsCommand.Execute();


                var res = excerptsCommand.Result;

                foreach (var result in res.Excerpts)
                {
                    Console.WriteLine(result);
                }

                Console.ReadKey();
            }

        }

        public void ImportPhotosMaterials()
        {
            var service = m_DataStore.PhotoService;
            var dirInfo = new DirectoryInfo(IMPORT_IMAGE_DIR);
            var files = dirInfo.GetFiles();
            var processor = new MaterialProcessor();


            var entities = CreateSelector().Add<Article>().
                Add<Grant>().
                Add<Discussion>().
                Add<Techno>().
                Add<Seminar>().
                Add<Conference>().Select(s => new DummyEntity(s.Id, s.ObjectType)).ToArray();

            var i = 0;
            var rand = new Random();

            foreach (var file in files)
            {
                if (i >= entities.Count()) break;

                var item = entities[i];

                var stream = new FileStream(file.FullName, FileMode.Open);
                service.ImportPhoto(processor, stream, file.Name, file.Name, false, item.Id, item.Id, item.ObjectType);

                Console.Write(".");
                i += rand.Next(1, 2);
            }

        }



        public void ImportUserPhotos()
        {
            Console.WriteLine("Current directory is {0}", Directory.GetCurrentDirectory());

            DeleteAll<Photo>();

            var service = m_DataStore.PhotoService;
            var dirInfo = new DirectoryInfo(IMPORT_USER_IMAGE_DIR);
            var files = dirInfo.GetFiles();
            var processor = new AvatarProcessor();
            var users = m_DataStore.UserService.GetAll().ToArray();

            var i = 0;
            foreach (var file in files)
            {
                if (i >= users.Count()) break;

                var user = users[i++];

                var stream = new FileStream(file.FullName, FileMode.Open);
                service.ImportPhoto(processor, stream, file.Name, file.Name, false, user.Id, user.Id, user.ObjectType);

                Console.Write(".");
            }
        }

        public void TestPhotoConverter()
        {
            Console.WriteLine("Current directory is {0}", Directory.GetCurrentDirectory());
            var service = m_DataStore.PhotoService;
            var dirInfo = new DirectoryInfo(IMPORT_IMAGE_DIR);
            var files = dirInfo.GetFiles();
            var processor = new AvatarProcessor();
            foreach (var file in files)
            {
                var stream = new FileStream(file.FullName, FileMode.Open);
                service.ImportPhoto(processor, stream, file.Name, file.Name, false, 0, 0, null);
                Console.Write(".");
            }

        }

        public void DeleteAll<_T>() where _T : class
        {
            Console.WriteLine("Deleting {0}", typeof(_T).Name);
            m_DataContext.Transaction(s =>
                                           {
                                               var t = s.GetTable<_T>();
                                               t.DeleteAllOnSubmit(t);

                                           });
        }

        public void EmailTest()
        {
            var addr = "seavan@gmail.com";
            var from = "noreply@oilring.notamedia.ru";
            var text = "text <b>email</b> from here";

            MailMessage email = new MailMessage(from, addr, "Test email", text);

            email.IsBodyHtml = true;


            var sc = new System.Net.Mail.SmtpClient("localhost", 25);

            sc.Credentials = null;
            sc.UseDefaultCredentials = false;
            sc.EnableSsl = false;

            sc.Send(email);
        }

        public void DropAllRelations()
        {
            DeleteAll<_AuthorLink>();
            DeleteAll<_ContactUserLink>();
            DeleteAll<_GrantMemberLink>();
            DeleteAll<_ObjectAuthorLink>();
            DeleteAll<_ObjectAuthorReaderLink>();
            DeleteAll<_ObjectUserDelegateLink>();
            DeleteAll<_ObjectUserReaderLink>();
            DeleteAll<_ObjectUserVisitorLink>();
            DeleteAll<_OrganizationLink>();
            DeleteAll<_OrganizationMemberLink>();
            DeleteAll<_OuterLink>();
            DeleteAll<_PublicationLink>();
            DeleteAll<_RubricLink>();
            DeleteAll<_ScholarUserLink>();
            DeleteAll<_TagLink>();
            DeleteAll<_TechnoGrantLink>();
            DeleteAll<_WorkerUserLink>();
        }

        public DateTime[] RandomDateTimes(int _count, int _yearRange, int _monthRange, int _dayRange)
        {
            var random = new Random();
            var mediana = DateTime.Now;
            var result = new List<DateTime>();
            for (int i = 0; i < _count; ++i)
            {
                var d = mediana;
                d = d.AddYears(random.Next(-_yearRange, _yearRange))
                .AddMonths(random.Next(-_monthRange, _monthRange))
                .AddDays(random.Next(-_dayRange, _dayRange))
                .AddHours(random.Next(0, 24))
                .AddMinutes(random.Next(0, 60))
                .AddSeconds(random.Next(0, 60));
                result.Add(d);
            }
            return result.ToArray();
        }

        public string[] GetCities()
        {
            return new string[] {
"Алкмар", "Алмере", "Амерсфорт", "Амстердам", "Амстелвен", "Апелдорн", "Арнем", "Ассен", "Бреда", "Вейк-ан-Зее", "Гаага", "Гауда", "Гронинген", "Девентер", "Делфт", "Зволле", "Зутермер", "Зютфен", "Керкраде", "Лейден", "Лелистад", "Леуварден", "Маастрихт", "Мидделбург", "Неймеген", "Рейссен", "Роттердам", "Тилбург", "Утрехт", "Харлем", "Хертогенбос", "Хоорн", "Эйндховен", "Энсхеде"};
        }

        public string[] GetAddresses()
        {
            return new string[] { "Багратионовский концертный зал", "Лужники", "МИРЭА", "МГУ", "МГТУ", "Усадьба Рахманинова", "Зимний дворец", "Поселок Сараево", "Люксембург", "Штолленберг", "Усадьба Толстого", "Кремль", "Красная площадь" };
        }

        public string[] GetSpecialties()
        {
            return new string[] {
"Бондарь", "Бульдозерист", "Горняк", "Драпировщик", "Инженер", "Инженер-конструктор", "Инженер-системотехник", "Инженер-технолог", "Крановщик", "Лекальщик", "Литейщик", "Маляр", "Маркшейдер", "Машинист", "Металлург", "Монтажник", "Монтажник радиоэлектронной аппаратуры и приборов", "Моторист", "Плотник", "Радиомеханик", "Расточник", "Рихтовщик", "Сантехник", "Сварщик", "Слесарь", "Сталевар", "Столяр", "Столяр-краснодеревщик", "Строитель", "Технолог", "Токарь", "Токарь-карусельщик", "Фрезеровщик", "Холодильщик", "Шахтёр", "Шлифовщик", "Электрик"};
        }

        public string[] GetSpecialties2()
        {
            return new string[] {
"Авиадиспетчер", "Бортмеханик", "Боцман", "Воздухоплаватель", "Донкерман", "Капитан судна", "Кок", "Космонавт", "Лётчик", "Лоцман", "Матрос", "Моряк", "Рыбак", "Стюардесса", "Судовой механик", "Судовой электромеханик", "Тралмейстер", "Штурман"
        };
        }

        public string[] GetMessageSubjects()
        {
            return new string[] {
"Мировоззренческие основы воспитательной деятельности", 
"Кризис понимания как социально-философская проблема", 
"Влияние социальных мифов на общественное сознание россиян", 
"Концепция устойчивого развития: философские основания и социальные предпосылки", 
"Проблема справедливого мирового порядка", 
"Философские предпосылки смены образовательных парадигм", 
"Молодежная политика в свете новой образовательной парадигмы", 
"Специфика формирования мировоззрения молодежи в условиях идеологического и политического плюрализма", 
"Глобализация и проблема национального и государственного суверенитета", 
"Особенности политической социализации молодежи в современной России", 
"Электоральное поведение российской молодежи", 
"Особенности интеграции России в глобализирующемся мире", 
"Глобализация политических элит и национальные интересы", 
"Справедливость и политическая стабильность в современной России", 
"Мировоззренческие основы политической социализации"
        };
        }

        public string[] GetMessageBodies()
        {
            return new string[] {
"В \"Знак минус означает, что сила, действующая на тело, всегда противоположна по направлению радиус-вектору, направленному на тело, ...\" помоему неверно трактован знак \"минус\" в показателе гравитационной постоянной. Знак минус в ней вовсе не означает направления силы. Он определяет её величину. Минус меняет направление силы если стоит перед ней (силой). В показателе же он может влиять лишь на величину.", 
"Пришел сюда выяснить есть ли у гравитации скорость распространения. Или она мгновенна. Так и не понял. Я не физик. Просто любопытствующий. Вот например есть две звезды на расстоянии миллионов световых лет друг от друга. И вот по каким-то причинам одна из них резко исчезает. И вопрос - будет ли после этого оставшаяся звезда притягиваться гравитационными полями умершей? Или эти поля мгновенно исчезнут?", 
"Если скорость мгновенна. Значит потенциально можно передавать информацию на любые расстояния без задержек. Сверхчувствительный приемник будет улавливать гравитацию. А где-то будет меняться масса тела. И менять ее так чтобы например какая-то частота получилась. Чтобы прибор среди хаоса обнаружил эту частоту, и там уже как нить придумать на такой частоте и информацию передавать. Медленно может быть. Но зато мгновенно на любые расстояния. Например на марсоход.", 
"Скорость гравитации в физических теориях В теории гравитации Ньютона скорость гравитации не входит ни в одну формулу, считаясь бесконечно большой. В ОТО скорость гравитации равна скорости света.", 
"По современным данным, является универсальным взаимодействием в том смысле, что, в отличие от любых других сил, всем без исключения телам независимо от их массы и внутренней структуры в одной и той же точке пространства и времени придаёт одинаковое ускорение", 
"Вообще же рассматривать отклонение света чисто в Ньютоновой теории бессмысленно, так как для фотона будет не классический закон сложения скоростей, а СТО-шный (хотя для перпендикулярных движений они совпадают). И масса равна нулю.", 
"Радиосигнал, также как и световой сигнал, не может быть средством контроля за скоростью распространения гравитации. Электромагнитное излучение и гравитационное взаимодействие - принципиально разные формы существования материии не могут быть связаны в условиях, которые мы называем нормальные.", 
"Скорость распространения света - это черепашья скорость по сравнению со скоростью распространения гравитационного взаимодействия, и при этом ошибка в измерении ее скорости приближается к самой скорости света.", 
"Для оценки скорости распространения гравитации следует искать совешенно другие, принципиально другие методы, например возмущения в ходе течения времени и т.п.", 
"Скорость распространения гравитации является величиной, сильно зависящей от величины самой гравитации, от расстояния от источника гравитации, от методов измерения, поэтому говорить об этой скорости также невозможно, как говорится о соотношении неопределенностей в квантовой механике.",
"Мне кажется, что подобные работы только дискредитируют теорию относительности. Я не понимаю, как в экспериментальной работе может не быть раздела \"Результаты\". Если измерения действительно были проведены, то почему бы не опубликовать их результаты - - дату, время, смещение квазара? Однако Копейкин этого не сделал. Более того, в двух разных его статьях (http://xxx.itep.ru/abs/gr-qc/0206022 и http://xxx.itep.ru/abs/gr-qc/0212121), расчетные уравнения различаются. В первой статье у него delta = cg/c - 1, а во второй - delta = c/cg - 1. Причем нельзя это несоответствие списать на опечатку, так как в обоих статьях это уравнение встречается неоднократно. Непонятно, по какому уравнению насчитывается задержка, вызванная стационарным полем Юпитера? По уравнению (7) из первой статьи или по уравнению (29) из второй? Во второй статье приводится результат cg/c= 1.06+-0.21. Однако на сайте AstroNet и в широкой печати фигурирует значение cg/c=0.95+-0.25. Какой же результат был получен в действительности? ",

        };
        }

        public void ShuffleUserSpecialties()
        {
            var random = new Random();
            var sp2 = GetSpecialties2();
            RandomAction(1, 1, CreateSelector().Add<User>(), GetSpecialties(),
                (a, d) =>
                {
                    var obj = m_DataStore.UserService.GetById(a.Id);
                    obj.Specialty = d + "-" + sp2[random.Next(0, sp2.Length - 1)].ToLower();
                    m_DataStore.UserService.Update(obj);
                });
        }

        public void ShuffleUserPlaces()
        {
            var random = new Random();
            RandomAction(1, 1, CreateSelector().Add<User>(), GetCities(),
                (a, d) =>
                {
                    var obj = m_DataStore.UserService.GetById(a.Id);
                    obj.City = d;
                    m_DataStore.UserService.Update(obj);
                });
        }


        public void ShuffleSeminarPlaces()
        {
            var random = new Random();
            RandomAction(1, 1, CreateSelector().Add<Seminar>(), GetAddresses(),
                (a, d) =>
                {
                    var obj = m_DataStore.SeminarService.GetById(a.Id);
                    obj.Place = d;
                    m_DataStore.SeminarService.Update(obj);
                });
        }

        public string RandomString(string[] _src)
        {
            var rand = new Random();
            return _src[rand.Next(0, _src.Length - 1)];
        }

        public void ShuffleSeminarDates()
        {
            var random = new Random();
            RandomAction(1, 1, CreateSelector().Add<Seminar>(), RandomDateTimes(100, 0, 7, 10),
                (a, d) =>
                {
                    var obj = m_DataStore.SeminarService.GetById(a.Id);
                    obj.EventStartDate = d;
                    obj.EventEndDate = d.AddDays(random.Next(0, 30));
                    m_DataStore.SeminarService.Update(obj);
                });
        }

        private string[] USER_GROUPS = new string[] { "Друзья", "Семья", "Одногруппники", "Сокурсники", "Подружки", "Преподаватели" };

        public void CreateMessageStack(long _userId)
        {
            DeleteAll<PrivateMessage>();
            DeleteAll<PrivateMessageItem>();

            int maxMessageThreadCount = 5;
            int maxMessagePerThread = 7;

            var rand = new Random();
            var users = m_DataStore.UserService.GetAll().ToArray();

            maxMessageThreadCount = rand.Next(3, maxMessageThreadCount);

            for (int i = 0; i < maxMessageThreadCount; ++i)
            {
                var mpp = rand.Next(3, maxMessageThreadCount);
                var user = users[rand.Next(0, users.Length - 1)];
                
                bool initial = rand.Next(0, 2) > 0;
                PrivateMessageObject thread = null;
                if( initial )
                {
                    thread = m_DataStore.PrivateMessageService.CreateThread(user.Id, _userId, RandomString(GetMessageSubjects()),
                        RandomString(GetMessageBodies()));
                }
                else
                {
                    thread = m_DataStore.PrivateMessageService.CreateThread(_userId, user.Id, RandomString(GetMessageSubjects()),
                        RandomString(GetMessageBodies()));
                }

                for (int j = 0; j < mpp; ++j)
                {
                    initial = rand.Next(0, 2) > 0;

                    var t = initial ?
                        (m_DataStore.PrivateMessageService).ReplyTo(thread.Id, _userId, RandomString(GetMessageBodies())) :
                        (m_DataStore.PrivateMessageService).ReplyTo(thread.Id, user.Id, RandomString(GetMessageBodies()));
                }
            }
        }

        public void RecreateFriendLinks()
        {
             DeleteAll<_FriendLink>();
            RandomAction(1, 3, CreateSelector().Add<User>(), m_DataStore.UserService.GetAll().ToArray(),
    (a, user) => { m_DataStore.UserService.CreateRelation("FriendLink", user, a.Id, a.ObjectType); });
        }

        public void RecreateFriendLinks(long _userId)
        {
            /*
            DeleteAll<_FriendLink>();
            RandomAction(30, 40, new UserObject[] { m_DataStore.UserService.GetById(_userId) }.AsEnumerable(), CreateSelector().Add<User>().ToArray(),
    (user, a) => { m_DataStore.UserService.CreateRelation("FriendLink", user, a.Id, a.ObjectType); });

            DeleteAll<User_Group>();
            foreach (var a in USER_GROUPS)
            {
                var userGroup = m_DataStore.User_GroupService.CreateItem();
                userGroup.Title = a;
                userGroup.REL_Id = _userId;
                userGroup.REL_ObjectType = "user";
                m_DataStore.User_GroupService.Insert(userGroup);
            }
            */
            var users = m_DataStore.UserService.GetRelated("FriendLink", _userId, "user");
            var groups = m_DataStore.User_GroupService.GetRelated("User_GroupObject_ManyToOne", _userId, "user").ToArray();
            var index = 0;
            var rand = new Random();
            foreach(var u in users)
            {
                m_DataStore.UserService.CreateRelation("GroupFriendLink", m_DataStore.UserService.GetById(u.Id),
                                                       groups[index%(groups.Length)].Id, "user_group"
                    );

                index += rand.Next(10);

            }

        }

        public void RecreateConferenceAuthorAndReaderLinks()
        {
            RandomAction(1, 6, CreateSelector().Add<Conference>(), m_DataStore.UserService.GetAll().ToArray(),
                (a, user) => { m_DataStore.UserService.CreateRelation("ObjectAuthorReader", user, a.Id, a.ObjectType); });

            RandomAction(1, 6, CreateSelector().Add<Conference>(), m_DataStore.UserService.GetAll().ToArray(),
                (a, user) => { m_DataStore.UserService.CreateRelation("ObjectUserVisitor", user, a.Id, a.ObjectType); });

            RandomAction(1, 2, CreateSelector().Add<Conference>(), m_DataStore.UserService.GetAll().ToArray(),
                (a, user) => { m_DataStore.UserService.CreateRelation("ObjectAuthor", user, a.Id, a.ObjectType); });

        }

        public void RecreateSeminarAuthorReaderLinks()
        {
            DeleteAll<_ObjectAuthorReaderLink>();
            RandomAction(1, 6, CreateSelector().Add<Seminar>(), m_DataStore.UserService.GetAll().ToArray(),
                (a, user) => { m_DataStore.UserService.CreateRelation("ObjectAuthorReader", user, a.Id, a.ObjectType); });
        }

        public void RecreateUserVisitorLinks()
        {
            DeleteAll<_ObjectUserVisitorLink>();
            RandomAction(1, 10, CreateSelector().Add<Seminar>(), m_DataStore.UserService.GetAll().ToArray(),
                (a, user) => { m_DataStore.UserService.CreateRelation("ObjectUserVisitor", user, a.Id, a.ObjectType); });
        }

        public void RecreateSeminarOrganizerLinks()
        {
            DeleteAll<_OrganizationLink>();
            RandomAction(1, 3, CreateSelector().Add<Seminar>(), m_DataStore.OrganizationService.GetAll().ToArray(),
                (a, user) => { m_DataStore.OrganizationService.CreateRelation("Organizers", user, a.Id, a.ObjectType); });
        }

        public void RecreateUserFavouriteLinks()
        {
            DeleteAll<_UserFavouriteLink>();
            RandomAction(10, 20, CreateSelector().AllEntities(), m_DataStore.UserService.GetAll().ToArray(),
                (a, user) => { m_DataStore.UserService.CreateRelation("UserFavourites", user, a.Id, a.ObjectType); });
        }


        public void RecreateAuthorLinks()
        {
            DeleteAll<_AuthorLink>();
            RandomAction(1, 4, CreateSelector().AllEntities(), m_DataStore.UserService.GetAll().ToArray(),
                (a, user) => { m_DataStore.UserService.CreateRelation("ObjectAuthor", user, a.Id, a.ObjectType); });
        }

        public void RecreateTagRelations()
        {
            DeleteAll<_TagLink>();
            RandomAction(1, 4, CreateSelector().AllEntities().Add<User>(), m_DataStore.TagService.GetAll().ToArray(),
                (a, tag) => { m_DataStore.TagService.CreateRelation("Tags", tag, a.Id, a.ObjectType); });
        }

        public void DeleteRubricRelationArticles()
        {
            RandomAction(1, 1, CreateSelector().Add<Article>(), m_DataStore.RubricService.GetAll().ToArray(),
                (a, rubric) =>
                {
                    m_DataStore.ArticleService.DeleteAllRelation("Rubrics", m_DataStore.ArticleService.GetById(a.Id));
                    //                    m_DataStore.RubricService.CreateRelation("Rubrics", rubric, a.Id, a.ObjectType);
                });
        }

        public void DeleteTagRelationArticles()
        {
            RandomAction(1, 1, CreateSelector().Add<Article>(), m_DataStore.TagService.GetAll().ToArray(),
                (a, rubric) =>
                {
                    m_DataStore.ArticleService.DeleteAllRelation("Tags", m_DataStore.ArticleService.GetById(a.Id));
                    //                    m_DataStore.RubricService.CreateRelation("Rubrics", rubric, a.Id, a.ObjectType);
                });
        }

        public void RecreateTagRelationsArticles()
        {
            DeleteAll<_TagLink>();
            DeleteAll<_TagRubricLink>();
            RandomAction(1, 4, CreateSelector().Add<Article>(), m_DataStore.TagService.GetAll().ToArray(),
                (a, tag) => { m_DataStore.TagService.CreateRelation("Tags", tag, a.Id, a.ObjectType); });
        }

        public void RecreateRubricRelationArticles()
        {
            DeleteAll<_TagLink>();
            RandomAction(1, 1, CreateSelector().Add<Article>(), m_DataStore.RubricService.GetAll().ToArray(),
                (a, rubric) =>
                {
                    m_DataStore.ArticleService.DeleteAllRelation("Rubrics", m_DataStore.ArticleService.GetById(a.Id));
                    m_DataStore.RubricService.CreateRelation("Rubrics", rubric, a.Id, a.ObjectType);
                });
        }

        public void RecreateRubricRelation()
        {
            DeleteAll<_RubricLink>();
            RandomAction(1, 4, CreateSelector().AllEntities(), m_DataStore.RubricService.GetAll().ToArray(),
                (a, rubric) => { m_DataStore.RubricService.CreateRelation("Rubrics", rubric, a.Id, a.ObjectType); });
        }

        public class ResultList : List<IDatabaseEntity>
        {
            private DataContext m_Context;

            public ResultList(DataContext _context)
            {
                m_Context = _context;
            }

            public ResultList Add<_T>() where _T : class
            {
                this.AddRange(m_Context.GetTable<_T>().Cast<IDatabaseEntity>().AsEnumerable());
                return this;
            }

            public ResultList AllEntities()
            {
                Add<Article>();
                Add<Grant>();
                Add<Discussion>();
                Add<Event>();
                Add<Techno>();
                Add<Seminar>();
                Add<Journal>();
                Add<Conference>();
                return this;
            }
        }

        public ResultList CreateSelector()
        {
            return new ResultList(m_DataContext.ReadOnlyContext);
        }

        public void RandomAction<_T, _C>(int _min, int _max, IEnumerable<_T> _target, _C[] _operand,
            Action<_T, _C> _action)
        {
            var random = new Random();
            var c = _target.Count();
            var ci = 0;
            Console.Clear();
            Console.WriteLine("Processing {0}", typeof(_T).Name);
            foreach (var item in _target)
            {
                Console.SetCursorPosition(0, 1);
                var rc = random.Next(_min, Math.Min(_operand.Length, _max));
                for (int i = 0; i < rc; ++i)
                {
                    int index = random.Next(0, _operand.Length - 1);
                    _action(item, _operand[index]);
                }
                ++ci;
                Console.Write("{0} of {1}", ci, c);
            }
            Console.WriteLine();
        }

        public string XssFree(string _value)
        {
            var res = AntiXss.HtmlEncode(_value);
            return res;
        }

        private void XssTest()
        {
            while(true)
            {
                var s = Console.ReadLine();
                Console.WriteLine(XssFree(s));
            }
        }


        public void Test()
        {
 //           XssTest();
            CreateMessageStack(174);
            
 //           RecreateFriendLinks(174);
            //           ShuffleUserPlaces();
            //           ShuffleUserSpecialties();
            //SphinxTester();
            //ImportPhotosMaterials();
            //ImportUserPhotos();
            //TestPhotoConverter();
            //RecreateConferenceAuthorAndReaderLinks();
            //RecreateRubricRelationArticles();
            //DeleteRubricRelationArticles();

            //RecreateTagRelationsArticles();


            //EmailTest();
            //RecreateSeminarAuthorReaderLinks();
            //ShuffleSeminarPlaces();
            //ShuffleSeminarDates();
            //RecreateSeminarOrganizerLinks();
            //RecreateUserVisitorLinks();
            //RecreateUserFavouriteLinks();

            /*           DeleteAll<_RubricLink>();
                       DeleteAll<_TagLink>();
                       DeleteAll<_TagRubricLink>();
                       RecreateRubricRelation();
                       RecreateTagRelations(); */
            //RecreateAuthorLinks();
            //
        }
    }
}