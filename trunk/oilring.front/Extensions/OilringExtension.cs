using System.Globalization;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using admin.web.common;
using Notamedia.Oilring.Database.DataAccess;
using Notamedia.Oilring;
using System.Linq.Expressions;
using System.Reflection;
using Notamedia.Oilring.Community.Common;
using System.Web;
using Database.Entities;
using Web.Common.Models;

namespace System
{
    public static class OilringExtension
    {


        public static string VersionInfo()
        {
            return Assembly.GetExecutingAssembly().GetName().Version.Build.ToString();
        }



        public static MvcHtmlString CustomLabelFor<T, V>(this HtmlHelper<T> _html, Expression<Func<T, V>> _expr, bool _noSemiColon = false)
        {
            var met = ModelMetadata.FromLambdaExpression(_expr, _html.ViewData);
            var pname = met.PropertyName;
            var title = met.GetDisplayName();
            if( !_noSemiColon && (title.Length > 0) && (title[title.Length - 1] != ':') )
            {
                title += ":";
            }
            return MvcHtmlString.Create(String.Format("<label for='{0}' class='name'>{1}</label>", pname, title));
        }

        public static MvcHtmlString CustomEditorFor<T, V>(this HtmlHelper<T> _html, Expression<Func<T, V>> _expr)
        {
            return _html.EditorFor(_expr);
            /*var met = ModelMetadata.FromLambdaExpression(_expr, _html.ViewData);
            var pname = met.PropertyName;
            return MvcHtmlString.Create(String.Format("<label for='{0}' class='name'>{1}</label>", met.DisplayName)); */
        }

        public static void RenderEditor<T, V>(this HtmlHelper<T> _html, Expression<Func<T, V>> _expr, bool withLabel = true, string _note = null)
        {
            _html.ViewContext.Writer.WriteLine("<div class='field'>");
            if (withLabel) _html.ViewContext.Writer.WriteLine(_html.CustomLabelFor(_expr));
            _html.ViewContext.Writer.WriteLine( _html.EditorFor(_expr));
            if (_note != null)
            {
                _html.ViewContext.Writer.WriteLine("<div class='note'>{0}</div>", _note);
            }
            // validation messages
            _html.ViewContext.Writer.WriteLine("</div>");
        }

        public static void RenderLiEditor<T, V>(this HtmlHelper<T> _html, Expression<Func<T, V>> _expr, bool withLabel = true, string _note = null)
        {
            _html.ViewContext.Writer.WriteLine("<li class='field'>");
            if (withLabel) _html.ViewContext.Writer.WriteLine(_html.CustomLabelFor(_expr, true));
            _html.ViewContext.Writer.WriteLine(_html.EditorFor(_expr));

            if (_note != null)
            {
                _html.ViewContext.Writer.WriteLine("<div class='note'>{0}</div>", _note);
            }

            _html.ViewContext.Writer.WriteLine("</li>");
        }

        public static void RenderDateEditor<T, DateTime>(this HtmlHelper<T> _html, Expression<Func<T, DateTime>> _expr, string additionalClass = null, string relParam = null)
        {
            //_html.ViewContext.Writer.WriteLine("<div class='dateInput'>");
            //if (withLabel)
            //{
            //    _html.ViewContext.Writer.WriteLine(_html.CustomLabelFor(_expr));
            //}
            //_html.ViewContext.Writer.WriteLine(_html.EditorFor(_expr, "Date"));

            //_html.ViewContext.Writer.WriteLine("</div>");
            //_html.ViewContext.Writer.WriteLine("<span class='dateDoor'><span>Календарь</span></span>");

            //if (_note != null)
            //{
            //    _html.ViewContext.Writer.WriteLine("<div class='note'>{0}</div>", _note);
            //}

            _html.ViewContext.Writer.WriteLine("<span class='dateDoor _datepicker'><span>");

            string date = _html.DisplayFor(_expr).ToString();
            if (!string.IsNullOrEmpty(date))
            {
                var dd = System.DateTime.Parse(date);
                _html.ViewContext.Writer.WriteLine(dd.ToShortDateString());
            }
            else
            {
                _html.ViewContext.Writer.WriteLine("Выбрать дату");
            }

            _html.ViewContext.Writer.WriteLine("</span></span>");
            _html.ViewContext.Writer.WriteLine("<div class='_datepickerHide'>");

            _html.ViewContext.Writer.WriteLine(_html.EditorFor(_expr, "Date", new { additionalClassView = additionalClass, relParamView = relParam }));
           
            _html.ViewContext.Writer.WriteLine("</div>");
        }

        /// <summary>
        /// Ссылка на изображение по умолчанию. Все изображения хранятся в одном каталоге
        /// </summary>
        /// <typeparam name="_T"></typeparam>
        /// <param name="_object">объект</param>
        /// <param name="_size"></param>
        /// <param name="_ext"></param>
        /// <returns></returns>
        public static string DefaultImageUri<_T>(_T _object, string _size = ConstSizes.ORIG, string _ext = "png") where _T : IDefaultPhotoable
        {
            // todo
            string photo = _object.AUTO_DefaultPhoto_Guid.ToString();
            return 
                photo != null ?
                String.Format(RES.IMAGE_CONTENT_URI + "{3}/{4}/{0}.{1}.{2}", photo, _size, _ext, _object.ObjectType.Trim(), _object.Id)
                : String.Format(RES.I_CONTENT_URI + "{0}.{1}.{2}", "default", _size, "png");
        }


        public static string DefaultImage<_T>(_T _object, string _size = ConstSizes.ORIG, string _add = "", string _ext = "png") where _T : IDefaultPhotoable
        {
            return DefaultPhotoAvailable(_object, _size, _ext) ? String.Format("<img src='{0}' alt {1}/>", DefaultImageUri(_object, _size, _ext), _add) : "";
        }

        public static bool DefaultPhotoAvailable<_T>(_T _object, string _size = ConstSizes.ORIG, string _ext = "png") where _T : IDefaultPhotoable
        {
            return _object.AUTO_DefaultPhoto_Guid != null;
        }
        /// <summary>
        /// Перевод времени в формат: 00 месяц 0000 г.
        /// </summary>
        public static string ToStringNormalDate(this DateTime str)
        {
            return str.ToString("dd MMMM yyyy", CultureInfo.CreateSpecificCulture("ru-RU")) + " г.";
        }

        /// <summary>
        /// Перевод времени в формат: 00.0000
        /// </summary>
        public static string ToStringEditFromMonthDate(this DateTime str)
        {
            return str.ToString("MM.yyyy", CultureInfo.CreateSpecificCulture("ru-RU"));
        }

        /// <summary>
        /// Перевод времени в формат: месяц `00
        /// </summary>
        public static string ToStringJournalDate(this DateTime str)
        {
            return str.ToString("MM `yy", CultureInfo.CreateSpecificCulture("ru-RU"));
        }

        /// <summary>
        /// Перевод времени в формат: 00 месяца 0000 г. в 00:00
        /// </summary>
        public static string ToStringVerboseDateTime(this DateTime str)
        {
            return str.ToString("d MMMM yyyy г. в HH:mm", CultureInfo.CreateSpecificCulture("ru-RU"));
        }

        /// <summary>
        /// Перевод времени в формат: 00 месяца 0000 г. в 00:00
        /// </summary>
        public static string ToStringToCalendarEvent(this DateTime str)
        {
            return str.ToString("M.d.yyyy", CultureInfo.CreateSpecificCulture("ru-RU"));
        }

        /// <summary>
        /// Перевод денежных сумм в формат 0 000 000
        /// </summary>
        public static string ToStringNormalSum(this int sum)
        {
            string source = sum.ToString();
            int length = source.Length;
            
            if (length > 3)
            {
                int counter = 0;
                string em = string.Empty;
                for(var i = length-1; i>=0; i--)
                {
                    if (counter == 3) 
                    { 
                        em += " ";
                        counter = 0;
                    }
                    em += source[i].ToString();
                    ++counter;
                }
                source = string.Empty;
                length = em.Length;
                for (var i = length - 1; i >= 0; i--)
                {
                    source += em[i].ToString();
                }
            }

            return source;
        }

        // <summary>
        /// Получаем базовые данные для просмотра
        /// </summary>
        public static BaseViewData<_T> GetBaseViewData<_T>(this ViewDataDictionary _vdd) where _T : class, IDatabaseEntity, new()
        {
            return new BaseViewData<_T>(_vdd);
        }

        public static string ToCounterWordForm(this long counter, string form1, string form2, string form5, bool onlyText = true)
        {
            var n = Math.Abs(counter) % 100;
            var n1 = n % 10;

            if (n > 10 && n < 20) return onlyText ? form5 : counter.ToString() + " " + form5;
            if (n1 > 1 && n1 < 5) return onlyText ? form2 : counter.ToString() + " " + form2;
            if (n1 == 1) return onlyText ? form1 : counter.ToString() + " " + form1;

            return onlyText ? form5 : counter.ToString() + " " + form5;
        }

        public static string ToStringAge(this DateTime BirthDate)
        {
            int year = DateTime.Now.Year - BirthDate.Year;
            if (DateTime.Now.AddYears(-year) < BirthDate)
            {
                --year;
            }
            return ((long)year).ToCounterWordForm("год", "года", "лет", false);
        }

        public static string ClassNameForTypeFile(this string title)
        {
            string className = string.Empty;
            string name = title;

            if (name.EndsWith(".doc") || name.EndsWith(".docx")) className = "icDoc";
            else if (name.EndsWith(".pdf")) className = "icPdf";
            else if (name.EndsWith(".xls") || name.EndsWith(".xlsx")) className = "icXls";
            else if (name.EndsWith(".rar")) className = "icRar";
            else if (name.EndsWith(".zip")) className = "icZip";
            else if (name.EndsWith(".bmp")) className = "icBmp";
            else if (name.EndsWith(".jpg") || name.EndsWith(".jpeg")) className = "icJpeg";
            else if (name.EndsWith(".tif") || name.EndsWith(".tiff")) className = "icTiff";
            else if (name.EndsWith(".ppt") || name.EndsWith(".pptx")) className = "icPpt";
            else className = "icOthers";

            return className;
        }

        /// <summary>
        /// CAPTHCHA изображение
        /// </summary>
        public static string CAPTCHAImage(this HtmlHelper helper, int height, int width, int charcount)
        {
            CaptchaImage.TextLength = charcount;
            CaptchaImage.LineNoise = LineNoiseLevel.Medium;
            CaptchaImage.FontWarp = FontWarpFactor.Medium;
            CaptchaImage.BackgroundNoise = BackgroundNoiseLevel.Medium;
            CaptchaImage image = new CaptchaImage
            {
                Width = width,
                Height = height
            };
            HttpRuntime.Cache.Add(
                image.UniqueId,
                image,
                null,
                DateTime.Now.AddSeconds(CaptchaImage.CacheTimeOut),
                System.Web.Caching.Cache.NoSlidingExpiration,
                System.Web.Caching.CacheItemPriority.NotRemovable,
                null
            );

            TagBuilder inputBuilder = new TagBuilder("input");
            inputBuilder.Attributes.Add("type", "hidden");
            inputBuilder.Attributes.Add("name", "captcha-guid");
            inputBuilder.Attributes.Add("value", image.UniqueId);

            TagBuilder imgBuilder = new TagBuilder("img");
            imgBuilder.Attributes.Add("src", "/" + helper.LC().LANG_CODE + "/User/ImageCaptcha?guid=" + image.UniqueId);
            imgBuilder.Attributes.Add("alt", "CAPTCHA Image");
            imgBuilder.Attributes.Add("width", width.ToString());
            imgBuilder.Attributes.Add("height", height.ToString());

            return inputBuilder.ToString(TagRenderMode.Normal) + imgBuilder.ToString(TagRenderMode.Normal);
        }

    }
}