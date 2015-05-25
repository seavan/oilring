using System;
using System.Linq;
using Database.Interfaces;
using Database.Entities;

namespace Database
{
    public class RelationOperand
    {
        public Func<long, string, IQueryable<IDatabaseEntity>> Select { get; set; }
        public Func<Type> SelectBy { get; set; }
        public Action<long, string, long, string> Insert { get; set; }
        public Action<long, string, long, string> Delete { get; set; }
        public Action<long, string> DeleteAll { get; set; }
        public Action<IDatabaseEntity, IDatabaseEntity> NotificationAdd { get; set; }
    }
}