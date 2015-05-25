	
/*
	Business Objects code generation
	Author: Samvel Avanesov 
	Mailto: seavan@gmail.com
	Table alias:	Comment
	File name: 	Comment.object.cs
*/
			

using System;
using System.ComponentModel.DataAnnotations;
using Notamedia.Oilring.Database;
using Notamedia.Oilring.Database.DataAccess;
using System.Collections.Generic;
using System.Linq;
using Database.Interfaces;
using Database.Entities;

namespace admin.db
{
    public partial class CommentObject : IManyToOne, IOwnerUserEnhancable
    {
        public int Level { get; set; }

    }
}