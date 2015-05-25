using System.Collections.Generic;
using Database.Entities;

namespace Database.Entities
{
    public class PreRelationInfo
    {
        public string Relation { get; set; }
        public string ObjectType { get; set; }

        public DummyEntity[] Relations { get; set; }

        public virtual IEnumerable<IDatabaseEntity> GetCreations()
        {
            return new IDatabaseEntity[] { };
        }
        //            public DummyEntity[] Creations { get; set; }
    }
}