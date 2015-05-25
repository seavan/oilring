	
/*
	User controller code generation
	Author: Samvel Avanesov 
	Mailto: seavan@gmail.com
	Table alias:	Report
	File name: 	Report.controller.cs
*/
			
using System;
using System.ComponentModel.DataAnnotations;
using admin.db;
using System.Linq;

namespace Notamedia.Oilring
{
    public class ReportController : admin.web.common.ReportController
    {
        protected override System.Linq.IQueryable<ReportObject> Filter(System.Linq.IQueryable<ReportObject> _src)
        {
            var p = Params;
            var r = base.Filter(_src).Where(s => s.REL_ObjectType == p.REL_ObjectType && s.REL_Id == p.REL_ObjectID).ToArray();
            
            return r.AsQueryable();
        }
    }
}	
