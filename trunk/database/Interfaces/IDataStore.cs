using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Database.Entities;

namespace Database.Interfaces
{
    public interface IDataStore
    {
        IDatabaseEntity Add(IDatabaseEntity _object, IDatabaseEntity _parent = null);
        IDatabaseEntity Resolve(long _id, string _otype);
        _T Resolve<_T>(long _id, string _otype) where _T : class;
    }
}
