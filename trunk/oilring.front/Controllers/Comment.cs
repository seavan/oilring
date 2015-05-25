	
/*
	User controller code generation
	Author: Samvel Avanesov 
	Mailto: seavan@gmail.com
	Table alias:	Comment
	File name: 	Comment.controller.cs
*/
			
using System;
using System.ComponentModel.DataAnnotations;
using admin.db;
using System.Collections.Generic;
using System.Linq;

namespace Notamedia.Oilring
{
    public class CommentController : admin.web.common.CommentController
    {
        protected override System.Linq.IQueryable<CommentObject> Filter(System.Linq.IQueryable<CommentObject> _src)
        {
            var p = Params;
            var r = base.Filter(_src);

            var list = new List<CommentObject>();
            SortNested(list, r.AsQueryable(), 0);
            return list.AsQueryable();
        }
    }
}	
