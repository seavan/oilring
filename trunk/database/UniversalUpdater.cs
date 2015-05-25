using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Data.Linq;
using Database.Interfaces;
using Common;
using Database.Entities;

namespace Database
{
    public abstract class UniversalUpdater
    {

        public IQueryable<IDatabaseEntity> TryFindTable(DataContext _context, string _objectType)
        {
            var t = Mapper.INST.GetEntityType(_objectType);
            if (t == null) return null;
            return _context.GetTable(t).Cast<IDatabaseEntity>();
        }

        protected int GetManyToManyRelationCount<_R>(DataContext _context, IDatabaseEntity _entity) where _R : class, IRelatable
        {
            return _context.GetTable<_R>().Count(s => s.REL_Id1.Equals(_entity.Id) && s.REL_ObjectType1.Equals(_entity.ObjectType));
        }

        public void Update(DataContext _context, long _id, string _otype)
        {
            var t = TryFindTable(_context, _otype);
            if (t == null)
            {
                return;
            }

            var obj = t.SingleOrDefault(s => s.Id.Equals(_id) && s.ObjectType.Equals(_otype));
            if (obj == null) return;
            Update(_context, obj);
        }

        public abstract void Update(DataContext _context, IDatabaseEntity _object);

        public void Init(DataContext _context, IDatabaseEntity _object)
        {
            //this.ResetDepDb(_object.GetType());
        }
    }
}
