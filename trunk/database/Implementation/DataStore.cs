using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Database.Interfaces;
using Database.Entities;
using Common;

namespace Database.Implementation
{
    public class DataStore : IDataStore
    {
        public IDatabaseEntity Add(IDatabaseEntity _object, IDatabaseEntity _parent = null)
        {
            var entityType = Mapper.INST.GetObjectType(_object.ObjectType);
            var entityService = Mapper.INST.GetServiceObject(entityType);
            var serviceType = entityService.GetType();

            // check one to many
            if (typeof(IManyToOne).IsAssignableFrom(entityType) && (_parent != null))
            {
                var m2o = (IManyToOne)_object;
                m2o.REL_Id = _parent.Id;
                m2o.REL_ObjectType = _parent.ObjectType;
            }

            // check one to one
            if (typeof(IOneToOne).IsAssignableFrom(entityType) && (_parent != null))
            {
                var o2o = (IOneToOne)_object;
                o2o.Id = _parent.Id;
                o2o.REF_ObjectType = _parent.ObjectType;
            }

            var method = serviceType.GetMethod("InsertOrFind", new Type[] { entityType });
            _object = method.Invoke(entityService, new object[] { _object }) as IDatabaseEntity;

            return _object;
        }

        public IDatabaseEntity Resolve(long _id, string _otype)
        {
            var service = (IDataService)Mapper.INST.GetService(_otype);
            return service.Resolve(_id);
        }

        public _T Resolve<_T>(long _id, string _otype) where _T : class
        {
            var service = (IDataService)Mapper.INST.GetService(_otype.Trim());
            if (typeof(_T).IsAssignableFrom(Mapper.INST.GetObjectType(_otype)))
            {
                return (_T)service.Resolve(_id);
            }
            return null;
        }
    }
}
