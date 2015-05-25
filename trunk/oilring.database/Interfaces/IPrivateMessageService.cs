	
/*
	Services interface code generation
	Author: Samvel Avanesov 
	Mailto: seavan@gmail.com
	Table alias:	PrivateMessage
	File name: 	IPrivateMessageService.interface.cs
*/
			

using System;
using System.ComponentModel.DataAnnotations;
using Notamedia.Oilring.Database;
using admin.db;
using Database.Interfaces;

namespace admin.db
{
    public partial interface IPrivateMessageService : IDataService<PrivateMessageObject>
    {
        PrivateMessageObject CreateThread(long _targetUserId, long _fromUserId, string _subject, string _text);
        PrivateMessageObject ReplyTo(long _threadId, long _fromUserId, string _text);
    }
}	
