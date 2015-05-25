using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Notamedia.Oilring.Database.DataAccess;
using Database.Entities;
using Database.Extensions;

namespace admin.db
{

    public class DatabaseEntity : IAutoUpdateable
    {
        public virtual void UpdateAuto()
        {
            this.ResetDep(GetType());
        }

        public bool PSEUDO_IsNew { get; set; }
        public bool PSEUDO_IsUserOwner { get; set; }
        public bool PSEUDO_IsUserAdmin { get; set; }
        public bool PSEUDO_IsUserEditable { get; set; }
        public UserObject OwnerUser { get; set; }
        public DateTime? PSEUDO_PreviousVisitDateTime { get; set; }
    }
}
