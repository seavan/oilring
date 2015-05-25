using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Web.Common.Controllers;
using Database.Entities;
using Web.Common.Modules;
using Common.IoC;
using admin.web.common;
using admin.db;

namespace admin.web.common
{
    public abstract class OilringModule<_T, _M, _F> : Module<_T, _M, _F>
        where _T : BaseUniversalController<_M>, new()
        where _M : class, IDatabaseEntity, new()
        where _F : class, new()
    {
        public OilringModule(bool _preserveRouteData = false) : base(_preserveRouteData)
        {
        }

        public OilringModule(IDatabaseEntity _model, bool _preserveRouteData = false)
            : base(_model, _preserveRouteData)
        {
        }

        protected override void Init()
        {
            this.SetOrder(OrderList.Default);
            var ds = MvcUnityContainer.Resolve<IDataServiceLocator>();
            this.SetUserTagFilter(String.Join(";", ds.TagService.GetTagUserSelection().Select(s => s.Id)));
        }

    }
}
