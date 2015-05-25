	
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

namespace admin.db
{
    public partial interface IPrivateMessageService : IDataService<PrivateMessageObject>
    {
    }
}	
