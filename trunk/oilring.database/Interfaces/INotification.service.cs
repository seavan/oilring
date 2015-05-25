	
/*
	Services interface code generation
	Author: Samvel Avanesov 
	Mailto: seavan@gmail.com
	Table alias:	Notification
	File name: 	INotificationService.interface.cs
*/
			

using System;
using System.ComponentModel.DataAnnotations;
using Notamedia.Oilring.Database;
using admin.db;
using Database.Interfaces;

namespace admin.db
{
    public partial interface INotificationService : IDataService<NotificationObject>
    {
    }
}	