using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web;
using Database.Entities;

namespace Web.Common.Models
{
    public class BaseViewData<_T >where _T : class, IDatabaseEntity, new()
    {
        public BaseViewData(ViewDataDictionary dic){
            m_ViewDataDictionary = dic;
            SubName = typeof(_T).Name.Replace("Object", "");
        }

        public long PagesCount
        {
            get { return GetInt(SubName + "_PagesCount"); }
            set { Set(SubName + "_PagesCount", value); }
        }

        public long GetInt(string _name)
        {
            try
            {
                return int.Parse(Get(_name).ToString());
            }
            catch (System.Exception)
            {
                return -1;
            }
        }

        public object Get(string _name)
        {
            return HttpContext.Current.Items[_name];
        }

        public void Set(string _name, object _value)
        {
            HttpContext.Current.Items[_name] = _value;
        }

        protected ViewDataDictionary m_ViewDataDictionary = new ViewDataDictionary();
        protected static string SubName;


    }
}
