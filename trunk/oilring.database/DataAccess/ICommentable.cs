using System;
using Database.Entities;

namespace Notamedia.Oilring.Database.DataAccess
{
    public interface ICommentable : IDatabaseEntity
    {
        int AUTO_CommentCount { get; set; }
        DateTime? AUTO_Comment_LastDateTime { get; set; }
    }
}