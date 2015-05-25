using System;
using System.Linq;
using Web.Common.Modules;

namespace Web.Common.Filters
{
    public interface IFilter<_T>
    {
        Func<ModuleParams, IQueryable<_T>, IQueryable<_T>> GetFilter();

        bool AppliesToParams(ModuleParams _params);

        string GetCacheSignature(ModuleParams _params);

        string GetName();
    }
}