using System;
using Notamedia.Oilring.Database.DataAccess;
using Database.Entities;
namespace admin.db
{
    public interface IFavorable
    {
    }

    public interface IUserEnhancable : IIdentifiedTyped
    {
        bool PSEUDO_IsUserFavourite { get; set; }
        int PSEUDO_NewCommentCount { get; set; }
        bool PSEUDO_IsUserOwner { get; set; }
        bool PSEUDO_IsUserAdmin { get; set; }
        bool PSEUDO_IsUserEditable { get; set; }
        int AUTO_CommentCount { get; set; }
        long? Owner_User_ID { get; set; }
        DateTime? PSEUDO_PreviousVisitDateTime { get; set; }
    }

    public interface IOwnerUserEnhancable
    {
        long? Owner_User_ID { get; set; }
        UserObject OwnerUser { get; set; }
    }

    public interface ISenderUserEnhancable : IIdentifiedTyped
    {
        long REL_SenderUserId { get; set; }
        UserObject SenderUser { get; set; }
    }

    public interface IRelatedUserEnhancable : IIdentifiedTyped
    {
        long? REL_User_ID { get; set; }
        string REL_User_ObjectType { get; set; }
        UserObject RelatedUser { get; set; }
    }

    public interface IFriendEnhancable
    {
        long Id { get; set; }
        bool PSEUDO_IsInFriends { get; set; }
        bool PSEUDO_IsFriendRequestSent { get; set; }
        bool PSEUDO_Self { get; set; }
    }

    public interface IJoinableEventEnhancable : IIdentifiedTyped
    {
        bool PSEUDO_IsJoinRequestSent { get; set; }
        bool PSEUDO_IsJoinRequestAccepted { get; set; }
    }

}