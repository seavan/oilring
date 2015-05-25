	
/*
	Services interface code generation
	Author: Samvel Avanesov 
	Mailto: seavan@gmail.com
	Table alias:	MessageTemplate
	File name: 	IMessageTemplateService.interface.cs
*/
			

using System;
using System.ComponentModel.DataAnnotations;
using Notamedia.Oilring.Database;
using admin.db;
using System.Collections;
using System.Collections.Generic;

namespace admin.db
{
    public partial interface IMessageTemplateService
    {
        string SendEmail(string _type, string _email, SortedList<string, string> _parameters, bool _send = true);
    }
}	
