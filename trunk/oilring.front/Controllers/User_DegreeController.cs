	
/*
	User controller code generation
	Author: Samvel Avanesov 
	Mailto: seavan@gmail.com
	Table alias:	User_Degree
	File name: 	User_Degree.controller.cs
*/
			
using System;
using System.ComponentModel.DataAnnotations;
using admin.db;
using System.Web.Mvc;

namespace Notamedia.Oilring
{
    public class User_DegreeController : admin.web.common.User_DegreeController
    {
		public ActionResult GetUserDegreeForm()
		{
		    User_DegreeObject obj = new User_DegreeObject
		    {
                Id = 0,
                ObjectType = "user_degree"
		    };

		    return PartialView("ListItemForEdit", obj);
		}
    }
}	
