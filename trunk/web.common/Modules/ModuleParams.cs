using System;
using System.Web.Routing;
using System.Web;
using System.Collections.Specialized;

namespace Web.Common.Modules
{
    public class ModuleParams
    {
        protected RouteValueDictionary m_RouteValueDictionary = new RouteValueDictionary();

        #region Constructors
        public ModuleParams()
        {
        }

        public ModuleParams(HttpRequestBase _request)
        {
            m_RouteValueDictionary = new RouteValueDictionary();
            Merge(_request);
        }

        public ModuleParams(RouteValueDictionary _dict)
        {
            m_RouteValueDictionary = _dict;
        }
        #endregion

        public object Get(string _name)
        {
            return m_RouteValueDictionary[_name];
        }

        #region Converters

        public _DT GetEnum<_DT>(string _name)
        {
            try
            {
                return (_DT)Enum.Parse(typeof(_DT), Get(_name).ToString());
            }
            catch (System.Exception)
            {
                return default(_DT);
            }
        }

        public long GetInt(string _name)
        {
            try
            {
                return long.Parse(Get(_name).ToString());
            }
            catch (System.Exception)
            {
                return -1;
            }
        }

        public RouteValueDictionary GetParams()
        {
            return m_RouteValueDictionary;
        }

        public string GetString(string _name)
        {
            return Get(_name) != null ? Get(_name).ToString() : "";
        }

        public ModuleParams Merge(NameValueCollection _p)
        {
            var p = _p;
            for (int i = 0; i < _p.Count; ++i )
            {
                m_RouteValueDictionary[_p.Keys[i]] = p[i];                
            }
            return this;
        }

        public ModuleParams Merge(RouteValueDictionary _p)
        {
            var p = _p;
            foreach (var i in _p)
            {
                m_RouteValueDictionary[i.Key] = i.Value;
            }
            return this;
        }

        public ModuleParams Merge(ModuleParams moduleParams)
        {
            var p = moduleParams.GetParams();
            foreach (var i in p)
            {
                //if (m_RouteValueDictionary[i.Key] == null)
                {
                    m_RouteValueDictionary[i.Key] = i.Value;
                }
            }
            return this;
        }

        public ModuleParams Merge(HttpRequestBase _req)
        {

            foreach (var i in _req.Params.AllKeys)
            {
                //if (m_RouteValueDictionary[i.Key] == null)
                {
                    m_RouteValueDictionary[i] = _req.Params[i];
                }
            }
            return this;
        }

        public void Set(string _name, object _value)
        {
            m_RouteValueDictionary[_name] = _value;
        }

        public void SetEnum<T>(string _name, T _value)
        {
            m_RouteValueDictionary[_name] = Enum.Format(typeof(T), _value, "D"); 
        }
        #endregion

        #region Properties

        public string Action { get { return GetString("action"); } set { Set("action", value);}}

        public long CurrentUserId
        {
            get { return GetInt("CurrentUserId"); }
            set { Set("CurrentUserId", value); }
        }

        public string FilterLetter
        {
            get { return GetString("FilterLetter"); }
            set { Set("FilterLetter", value); }
        }

        public bool HasRelated
        {
            get { return REL_ObjectType != null; }

        }

        public long Id
        { 
            get { return GetInt("id"); } 
            set { Set("id", value); }
        }

        public bool IsAdmin { get; set; }


        public string Lang
        {
            get { return GetString("Lang"); }
            set { Set("Lang", value); }
        }

        public string ModuleId
        {
            get { return GetString("ModuleId"); }
            set { Set("ModuleId", value); }
        }

        public long Page
        {
            get { return GetInt("Page"); }
            set { Set("Page", value); }
        }

        public long PageSize
        {
            get { return GetInt("PageSize"); }
            set { Set("PageSize", value); }
        }

        public long ParentID
        {
            get { return GetInt("ParentID"); }
            set { Set("ParentID", value); }
        }

        public long REL_ObjectID
        {
            get
            {
                return GetInt("REL_ObjectID");
            }
            set
            {
                Set("REL_ObjectID", value);

            }
        }

        public string REL_ObjectType
        {
            get { return GetString("REL_ObjectType"); }
            set { Set("REL_ObjectType", value); }
        }

        public string REF_ObjectType
        {
            get { return GetString("REF_ObjectType"); }
            set { Set("REF_ObjectType", value); }
        }

        public string Relation
        {
            get { return GetString("Relation"); }
            set { Set("Relation", value); }
        }

        public string SearchQueryString
        {
            get { return GetString("SearchQueryString"); }
            set { Set("SearchQueryString", value); }
        }

        public long UserFilter
        {
            get { return GetInt("UserFilter"); }
            set { Set("UserFilter", value); }
        }

        public string ViewName
        {
            get { return GetString("ViewName"); }
            set { Set("ViewName", value); }
        }

        public long ShowDrafts 
        {
            get { return GetInt("ShowDrafts"); }
            set { Set("ShowDrafts", value); }
        }

        public long OnlyDrafts
        {
            get { return GetInt("OnlyDrafts"); }
            set { Set("OnlyDrafts", value); }
        }

        public long OnlyPublished
        {
            get { return GetInt("OnlyPublished"); }
            set { Set("OnlyPublished", value); }
        }
        #endregion
    }
}