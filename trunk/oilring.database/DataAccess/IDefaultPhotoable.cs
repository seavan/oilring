using System;
using Database.Entities;

namespace Notamedia.Oilring.Database.DataAccess
{
    public interface IDefaultPhotoable : IDatabaseEntity
    {
        Guid? AUTO_DefaultPhoto_Guid { get; set; }
        string AUTO_DefaultPhoto_Alt { get; set; }
    }
}