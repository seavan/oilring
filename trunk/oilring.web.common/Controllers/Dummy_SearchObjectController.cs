	
/*
	Common controller code generation
	Author: Samvel Avanesov 
	Mailto: seavan@gmail.com
	Table alias:	Dummy_SearchObject
	File name: 	Dummy_SearchObject.controller.cs
*/
			

using System;
using System.ComponentModel.DataAnnotations;
using Notamedia.Oilring.Database;
using admin.db;
using Notamedia.Oilring.Database.DataAccess;
using System.Linq;
using System.Web.Mvc;
using System.Collections.Generic;
using Sphinx.Client.Connections;
using Sphinx.Client.Commands.Search;
using Sphinx.Client.Commands.BuildExcerpts;
using Database.Entities;
using Web.Common.Modules;
using Web.Common.Filters;

namespace admin.web.common
{
    /// <summary>
    /// Фильтр для фильтрации контента по категориям
    /// </summary>
    public class SearchTypeSelectionItem
    {
        /// <summary>
        /// Отображаемое имя типа контента
        /// </summary>
        public string DisplayName { get; set; }
        /// <summary>
        /// Количество найденных объектов этого типа
        /// </summary>
        public int Count { get; set; }
        /// <summary>
        /// Тип объекта
        /// </summary>
        public string ObjectType { get; set; }
        /// <summary>
        /// Является ли фильтр активным
        /// </summary>
        public bool Selected { get; set; }
    }

    public class SearchTypeSelection : List<SearchTypeSelectionItem>
    {
        public string ModuleId { get; set; }
    }

    public partial class Dummy_SearchObjectController : OilringBaseUniversalController<Dummy_SearchObjectObject>
    {
        public Dummy_SearchObjectController()
        {
            m_PreFilterList.ClearPreFilters();
            m_PreFilterList.ClearPostSelectors();

            m_PreFilterList.RegisterSelector(
                new BasicFilter<IDatabaseEntity>(
                    "SearchByString",
                    (p, src) =>
                    {
                        return SphinxSearch(p.SearchQueryString);
                    },
                        (p) => {
                            return !String.IsNullOrEmpty(p.SearchQueryString); 
                        },
                        (p) => { return p.SearchQueryString.Split(' '); }
                    )
                    );

            m_PreFilterList.RegisterSelector(
                new BasicFilter<IDatabaseEntity>(
                    "SearchByTag",
                    (p, src) =>
                    {
                        return new Dummy_SearchObjectService().SearchByTagId(p.GetSearchTagId());
                    },
                        (p) => { return p.GetSearchTagId() > 0; },
                        (p) => { return new object[] { p.GetSearchTagId() }; }
                    )
                    );

            m_PreFilterList.RegisterSelector(
                new BasicFilter<IDatabaseEntity>(
                    "SearchByRubric",
                    (p, src) =>
                    {
                        return new Dummy_SearchObjectService().SearchByRubricId(p.GetSearchRubricId());
                    },
                        (p) => { return p.GetSearchRubricId() > 0; },
                        (p) => { return new object[] { p.GetSearchRubricId() }; }
                    )
                    );

            m_PreFilterList.RegisterPreFilter(
                new BasicFilter<IDatabaseEntity>(
                    GetType().Name + "_FilterType",
                    (_params, _q) =>
                    {
                        return _q.Where(s => s.ObjectType.Equals(_params.REL_ObjectType));
                    },
                    (_params) => { return !String.IsNullOrEmpty(_params.REL_ObjectType); },
                    (_params) => { return new object[] { _params.REL_ObjectType }; }
                    )
                );

            m_PreFilterList.RegisterPreFilter(
                new BasicFilter<IDatabaseEntity>(
                    GetType().Name + "_Convert",
                    (_params, _q) => 
                    { 
                        var r = _q.ToArray().Select( s => DataStore.Resolve<ITitleable>(s.Id, s.ObjectType) ).Where( s => s != null).Cast<IDatabaseEntity>();
                        return r.ToArray().AsQueryable();
                    },
                    (_params) => { return true; },
                    (_params) => { return new object[] { "search_cnv" }; }
                    )
                );

            m_PreFilterList.RegisterPreFilter(new PageFilter<IDatabaseEntity>());
        }

        public ActionResult EntityTypeFilter()
        {
            var r = new SearchTypeSelection();
            r.Add(new SearchTypeSelectionItem() { DisplayName = "Все", ObjectType = "" });
            r.Add(new SearchTypeSelectionItem() { DisplayName = "Материалы", ObjectType = "article" });
            r.Add(new SearchTypeSelectionItem() { DisplayName = "Семинары", ObjectType = "seminar" });
            r.Add(new SearchTypeSelectionItem() { DisplayName = "Конференции", ObjectType = "conference" });
            r.Add(new SearchTypeSelectionItem() { DisplayName = "Дискуссии", ObjectType = "discussion" });
            r.Add(new SearchTypeSelectionItem() { DisplayName = "Гранты", ObjectType = "grant" });
            r.Add(new SearchTypeSelectionItem() { DisplayName = "Технологии", ObjectType = "techno" });
            r.Add(new SearchTypeSelectionItem() { DisplayName = "Новости", ObjectType = "event" });

            var mp = GetModuleParams();
            mp.PageSize = 0;
            r.ModuleId = mp.ModuleId;
            var ot = mp.REL_ObjectType;
            foreach (var i in r)
            {
                mp.REL_ObjectType = i.ObjectType;
                i.Selected = ot == i.ObjectType;
                i.Count = GetUntypedCachedEnhancedUltraItems<IDatabaseEntity>(mp, false).Count();
            }

            return View(r);
        }

        protected override System.Web.Mvc.ActionResult BaseAction(ModuleParams _params = null, bool _enhance = true)
        {
            var moduleParams = _params != null ? _params : GetModuleParams();
            var vn = moduleParams.ViewName;
            var res = GetUntypedCachedEnhancedUltraItems<ITitleable>(moduleParams, _enhance);
            return String.IsNullOrEmpty(vn) ? View(res) : View(vn, res);

        }

        public ActionResult Search()
        {
            return ListItems();
        }

        public IQueryable<ITitleable> SphinxSearch(string _text)
        {
            using (ConnectionBase connection = new PersistentTcpConnection("localhost", 9312))
            {
                var q = _text;
                // Create new search query object and pass query text as argument
                SearchQuery searchQuery = new SearchQuery(q);

                // Set match mode to SPH_MATCH_EXTENDED2
                searchQuery.MatchMode = MatchMode.Extended2;
                // Add Sphinx index name to list
                searchQuery.Indexes.Add("articles");
                searchQuery.Indexes.Add("discussions");
                searchQuery.Indexes.Add("events");
                searchQuery.Indexes.Add("technos");
                searchQuery.Indexes.Add("seminars");
                searchQuery.Indexes.Add("grants");
                searchQuery.Indexes.Add("conferences");
                // Setup attribute filter
                //DateTime[] datesToExclude = new DateTime[] { DateTime.ParseExact("2005-05-05 20:07:09", "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture) };

                //searchQuery.AttributeFilters.Add("ObjectType", 0, true);
                // Set amount of matches will be returned to client 
                searchQuery.Limit = 100;

                // Create search command object
                SearchCommand searchCommand = new SearchCommand(connection);
                // Add newly created search query object to query list
                searchCommand.QueryList.Add(searchQuery);
                // Execute command on server and obtain results
                searchCommand.Execute();

                if (searchCommand.Result.QueryResults.Count == 0)
                {
                    Console.WriteLine("No results");
                    return null;
                }

                // Print results
                List<ITitleable> m_Results = new List<ITitleable>();

                foreach (SearchQueryResult result in searchCommand.Result.QueryResults)
                {
                    foreach (Match match in result.Matches)
                    {
                        var id = match.DocumentId;
                        var otype = match.AttributesValues["objecttype"].GetValue().ToString().Trim();

                        var iobj = DataStore.Resolve<ITitleable>(id, otype);
                        if (iobj != null){
                            m_Results.Add(iobj);
                        }

                    }
                }

                return m_Results.AsQueryable();

/*                Console.WriteLine("Excerpts:");
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

                Console.ReadKey();*/
            }
        }

    }
}	
