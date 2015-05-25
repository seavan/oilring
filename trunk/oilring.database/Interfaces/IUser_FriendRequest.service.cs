	
/*
	Services interface code generation
	Author: Samvel Avanesov 
	Mailto: seavan@gmail.com
	Table alias:	User_FriendRequest
	File name: 	IUser_FriendRequestService.interface.cs
*/
			

using System;
using System.ComponentModel.DataAnnotations;
using Notamedia.Oilring.Database;
using admin.db;
using Database.Interfaces;

namespace admin.db
{
    public partial interface IUser_FriendRequestService : IDataService<User_FriendRequestObject>
    {
    }
}	
