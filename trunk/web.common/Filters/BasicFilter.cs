using System;
using System.Linq;
using Web.Common.Modules;

namespace Web.Common.Filters
{
    public class BasicFilter<_T> : IFilter<_T>
    {
        public BasicFilter(
            string _name,
            Func<ModuleParams, IQueryable<_T>, IQueryable<_T>> _selector,
            Func<ModuleParams, bool> _appliesToParams,
            Func<ModuleParams, object[]> _getCacheSignature
            )
        {
            m_Selector = _selector;
            m_AppliesToParams = _appliesToParams;
            m_GetCacheSignature = _getCacheSignature;
            m_Name = _name;
        }

        private Func<ModuleParams, IQueryable<_T>, IQueryable<_T>> m_Selector;
        private Func<ModuleParams, bool> m_AppliesToParams;
        private Func<ModuleParams, object[]> m_GetCacheSignature;
        private string m_Name;

        public Func<ModuleParams, IQueryable<_T>, IQueryable<_T>> GetFilter()
        {
            return m_Selector;
        }

        public bool AppliesToParams(ModuleParams _params)
        {
            return m_AppliesToParams(_params);
        }

        public string GetCacheSignature(ModuleParams _params)
        {
            return String.Format("{0}:{1};", "", String.Join(FilterList<_T>.PARAM_SEPARATOR, m_GetCacheSignature(_params)));
        }

        public string GetName()
        {
            return m_Name;
        }

    }
}