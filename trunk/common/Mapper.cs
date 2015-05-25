using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
    public class Mapper
    {
        public Mapper()
        {
            /*this["article"] = "Article";
            this["conf"] = "Conference";
            this["disc"] = "Discussion";
            this["news"] = "Event";
            this["journal"] = "Journal";
            this["seminar"] = "Seminar";
            this["techno"] = "Techno";
            this["user"] = "User";
            this["grant"] = "Grant"; */
        }

        public void RegisterEntityType<_T, _O>(object _service)
        {
            var type = typeof(_T);
            var rtype = typeof(_O);
            var name = type.Name;
            var lname = name.ToLower();
            
            m_Map[lname] = name;
            m_Map[name] = name;
            m_BackMap[lname] = lname;
            m_BackMap[name] = lname;
            m_Types[name] = type;
            m_RTypes[name] = rtype;
            m_LowerTypes[name] = type;

            m_ServiceMap[type.Name.ToLower()] = _service;
            m_ServiceMap[rtype.FullName] = _service;
            m_ServiceMap[type.FullName] = _service;
        }

        public object GetService(string _typeCode)
        {
            return m_ServiceMap[_typeCode.Trim()];
        }

        public string GetUri(Type _t)
        {
            return _t.Name.Replace("Object", "");
        }

        public string GetTypeCode<_T>()
        {
            return MapToTypeCode(typeof(_T).Name.Replace("Object", ""));
        }

        public Type GetObjectType(string _otype)
        {
            var m = m_Map[_otype.Trim()];
            if (m == null) throw new SystemException("Not a supported type");
            return m_RTypes[m];
        }


        public Type GetEntityType(string _otype)
        {
            var m = m_Map[_otype.Trim()];
            if( m == null ) throw new SystemException("Not a supported type");
            return m_Types[m];
        }

        public object GetServiceObject(Type _otype)
        {
            var m = m_ServiceMap[_otype.FullName];
            if (m == null) throw new SystemException("Not a supported type");
            return m;
        }

        public string MapToTypeCode(string _otype)
        {
            return m_BackMap[_otype.Trim()];
        }

        public string MapToTypeName(string _otype)
        {
            return m_Map[_otype.Trim()];
        }

        private SortedList<string, Type> m_Types = new SortedList<string,Type>();
        private SortedList<string, Type> m_RTypes = new SortedList<string, Type>();
        private SortedList<string, Type> m_LowerTypes = new SortedList<string, Type>();
        private SortedList<string, string> m_Map = new SortedList<string, string>();
        private SortedList<string, string> m_BackMap = new SortedList<string, string>();
        private SortedList<string, object> m_ServiceMap = new SortedList<string, object>();
        
        public static Mapper INST = new Mapper();

    }
}
