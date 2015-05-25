using System.Collections.Generic;
using System.Linq;
using Database.Entities;

namespace Database.Entities
{
    public class RelationInfo<_M> : PreRelationInfo
    {
        public _M[] Creations { get; set; }

        public override IEnumerable<IDatabaseEntity> GetCreations()
        {
            return Creations.Cast<IDatabaseEntity>();
        }
    }
}