
/*
    Services code generation
    Author: Samvel Avanesov 
    Mailto: seavan@gmail.com
    Table alias:	User_Group
    File name: 	User_Group.service.cs
*/


using System;
using System.Linq;
using System.Data.Linq;
using System.ComponentModel.DataAnnotations;
using Notamedia.Oilring.Database;
using System.Collections.Generic;
using Notamedia.Oilring.Database.DataAccess;
namespace admin.db
{
    public partial class User_GroupService : IUser_GroupService
    {

        #region IUser_GroupService Members

        public void DeleteGroup(long _userId, long _groupId)
        {
            TraceContext.Transaction(
                s =>
                {
                    var fltoupdate = s.GetTable<_FriendLink>().Where(fl => fl.REL_User_Group_Id.Equals(_groupId) && (fl.REL_Id1.Equals(_userId) || fl.REL_Id2.Equals(_userId)));
                    foreach (var link in fltoupdate)
                    {
                        link.REL_User_Group_Id = null;
                    }
                    var groupToDelete = s.GetTable<User_Group>().Where(ug => ug.REL_Id.Equals(_userId) && ug.Id.Equals(_groupId));
                    s.GetTable<User_Group>().DeleteAllOnSubmit(groupToDelete);
               });
            ResetCache();
        }

        #endregion

        #region IUser_GroupService Members


        public void CreateGroup(long _userId, string _title)
        {
            var group = CreateItem();
            group.Title = _title;
            group.REL_Id = _userId;
            group.REL_ObjectType = "user";
            Insert(group);
            ResetCache();
        }

        #endregion

        #region IUser_GroupService Members


        public void AddToGroup(long _userId, long _groupId, long[] _ids)
        {
            var group = GetById(_groupId);
            if (group.REL_Id != _userId) return;

            foreach (var i in _ids)
            {
                DataServiceLocator.UserService.CreateRelation("GroupFriendLink", DataServiceLocator.UserService.GetById(i),
                                       _groupId, "user_group"
    );
            }
            ResetCache();
        }

        #endregion

        #region IUser_GroupService Members


        public void DeleteFromGroup(long _thisUserId, long _userId, long _groupId, bool _deleteFromList, bool _deleteFromFriends)
        {
            if (_deleteFromList)
            {
                DataServiceLocator.UserService.DeleteRelation("GroupFriendLink", DataServiceLocator.UserService.GetById(_userId),
                    _groupId, "user_group");
            }
            else
            {
                DataServiceLocator.UserService.DeleteRelation("FriendLink", DataServiceLocator.UserService.GetById(_thisUserId),
                    _userId, "user");
            }
            ResetCache();
        }

        #endregion
    }
}
