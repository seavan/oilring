	
/*
	Services interface code generation
	Author: Samvel Avanesov 
	Mailto: seavan@gmail.com
	Table alias:	Comment
	File name: 	ICommentService.interface.cs
*/
			

using System;
using System.ComponentModel.DataAnnotations;
using Notamedia.Oilring.Database;
using admin.db;
using Notamedia.Oilring.Database.DataAccess;
using Database.Interfaces;

namespace admin.db
{
    public partial interface ICommentService : IDataService<CommentObject>
    {
           void CheckVisit(long _userId, string _userType, ICommentable _item);
    }
}	
