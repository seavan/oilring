using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Notamedia.Oilring.Database.DataAccess;
using Microsoft.Practices.Unity;
using Database.Implementation;
using Database.Entities;
using Database.Interfaces;
using Common.IoC;

namespace admin.db
{
    public abstract class OilringDataService<T, M, C> :
        DataService<T, M, C>
        where T : class, IDatabaseEntity, new()
        where M : class, IDatabaseEntity, IAutoUpdateable, new()
        where C : IConvertibleFactory<T, M>, new()
    {
        public IDataServiceLocator DataServiceLocator
        {
            get
            { 
                return MvcUnityContainer.Container.Resolve<IDataServiceLocator>(); 
            }
        }
    }
}
