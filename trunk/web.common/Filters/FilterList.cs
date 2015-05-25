using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Web.Common.Modules;

namespace Web.Common.Filters
{
    public class FilterList<_T>
    {
        protected List<IFilter<_T>> m_List = new List<IFilter<_T>>();

        protected List<IFilter<_T>> m_PostFilter = new List<IFilter<_T>>();

        /// <summary>
        /// TODO: зачем list?
        /// </summary>
        protected List<IFilter<_T>> m_Selectors = new List<IFilter<_T>>();

        protected List<IFilter<_T>> m_PostSelectors = new List<IFilter<_T>>();

        public FilterList()
        {
        }

        public static string PARAM_SEPARATOR = ":";

        public void ClearPreFilters()
        {
            m_List.Clear();
        }

        public void ClearPostSelectors()
        {
            m_PostSelectors.Clear();
        }

        public IQueryable<_T> GetFiltered(ModuleParams _params)
        {
            var t = Selector(_params);
            t = ApplyAll(m_List, _params, t).AsQueryable();
            t = ApplyAll(m_PostFilter, _params, t).ToArray().AsQueryable();
//            t = ApplyAll(m_PostFilter, _params, t);
            return t;
        }

        public int GetFilteredCount(ModuleParams _params)
        {
            var t = Selector(_params);
            return ApplyAll(m_List, _params, t).Count();
        }

        public IQueryable<_T> GetConverted(ModuleParams _params)
        {
            var t = GetFiltered(_params);

            if (HasPostSelector)
            {
                t = PostSelector(_params, t);
            }
            return t;
        }
        
        IFilter<_T> GetApplyableSelector(ModuleParams _params)
        {
            foreach (var _selector in m_Selectors)
            {
                if (_selector.AppliesToParams(_params))
                {
                    return _selector;
                }
            }
            throw new SystemException("No suitable selector found");
        }

        public bool HasPostSelector
        {
            get
            {
                return m_PostSelectors.Count > 0;
            }
        }

        public IQueryable<_T> PostSelector(ModuleParams _params, IQueryable<_T> _arg)
        {
            return ApplyAll(m_PostSelectors, _params, _arg);
        }


        public string GetCacheSignature(ModuleParams _params)
        {
            string res = GetApplyableSelector(_params).GetCacheSignature(_params);
            foreach (var item in m_List)
            {
                if (item.AppliesToParams(_params))
                {
                    res += item.GetCacheSignature(_params);
                }
            }
            return res;
        }

        public IQueryable<_T> Selector(ModuleParams _params)
        {
            var q = new List<_T>().AsQueryable();
            return GetApplyableSelector(_params).GetFilter()(_params, q);
        }

        public IQueryable<_T> ApplyAll(IEnumerable<IFilter<_T>> _list, ModuleParams _params, 
                                       IQueryable<_T> _src)
        {
            foreach(var item in _list)
            {
                if( item.AppliesToParams(_params) )
                {
                    _src = item.GetFilter().Invoke(_params, _src);
                }
            }
            return _src;
        }


        public void RegisterSelector(IFilter<_T> _selector)
        {
            m_Selectors.Insert(0, _selector);
        }

        public void RegisterPostSelector(IFilter<_T> _selector)
        {
            m_PostSelectors.Add(_selector);
        }

        public void RegisterPostSelector<_O, _I>(IFilter<_T> _selector)
            where _O : class
            where _I : class
        {
            if (typeof(_I).IsAssignableFrom(typeof(_O)))
            {
                m_PostSelectors.Add(_selector);
            }
        }


        public void RegisterPreFilter(IFilter<_T> _filter)
        {
            m_List.Add(_filter);
        }

        public void RegisterPreFilter<_O, _I>(IFilter<_T> _filter) where _O : class where _I : class
        {
            if (typeof(_I).IsAssignableFrom(typeof(_O)))
            {
                RegisterPreFilter(_filter);
            }
        }

        public void RegisterPostFilter(IFilter<_T> _filter)
        {
            m_PostFilter.Add(_filter);
        }
    }
}