using System;
using System.Collections.Generic;
using System.Linq;
using Database.Interfaces;
using Database.Entities;

namespace Database
{
    public static class DataRelationRegistrar
    {
        static DataRelationRegistrar()
        {
            m_RegisteredRelations = new SortedList<string, RelationOperand>();
        }

        public static void Register(string _name, Func<long, string, IQueryable<IDatabaseEntity>> _Select,
                                    Action<long, string, long, string> _Insert, Action<long, string, long, string> _Delete, Action<long, string> _DeleteAll,
            Action<IDatabaseEntity, IDatabaseEntity> _NotificationAdd = null)
        {
            m_RegisteredRelations.Add(_name,
                                      new RelationOperand() {Select = _Select, Insert = _Insert, Delete = _Delete, DeleteAll = _DeleteAll, NotificationAdd = _NotificationAdd});
        }

        
        public static SortedList<string, RelationOperand> RegisteredRelations { get { return m_RegisteredRelations; } }
        private static SortedList<string, RelationOperand> m_RegisteredRelations;
    }
}