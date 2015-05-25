	
/*
	Services interface code generation
	Author: Samvel Avanesov 
	Mailto: seavan@gmail.com
	Table alias:	User_Group
	File name: 	IUser_GroupService.interface.cs
*/
			

using System;
using System.ComponentModel.DataAnnotations;
using Notamedia.Oilring.Database;
using admin.db;
using Database.Interfaces;

namespace admin.db
{
    public partial interface IUser_GroupService : IDataService<User_GroupObject>
    {
        void DeleteGroup(long _userId, long _groupId);
        void CreateGroup(long _userId, string _title);
        void AddToGroup(long _userId, long _groupId, long[] _ids);
        void DeleteFromGroup(long _thisUserId, long _userId, long _groupId, bool _deleteFromList, bool _deleteFromFriends);


    }
}	
