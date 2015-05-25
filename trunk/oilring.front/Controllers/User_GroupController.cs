
/*
    User controller code generation
    Author: Samvel Avanesov 
    Mailto: seavan@gmail.com
    Table alias:	User_Group
    File name: 	User_Group.controller.cs
*/

using System;
using System.ComponentModel.DataAnnotations;
using admin.db;
using System.Web.Mvc;
using Microsoft.Security.Application;
using System.Linq;

namespace Notamedia.Oilring
{
    public class User_GroupController : admin.web.common.User_GroupController
    {
        public JsonResult DeleteGroup(long REL_Id1, string REL_ObjectType1)
        {
            return JsonTryAuthenticatedAction(
                (id) =>
                    User_GroupService.DeleteGroup(id, REL_Id1)
                );
            
        }

        public JsonResult DeleteFromGroup(long userId, long groupId, int deleteFromFriends, int deleteFromList)
        {
            return JsonTryAuthenticatedAction(
                (id) =>
                    User_GroupService.DeleteFromGroup(id, userId, groupId, deleteFromList > 0, deleteFromFriends > 0)
                );

        }


        public JsonResult CreateGroup(string title)
        {
            title = AntiXss.HtmlEncode(title);
            return JsonTryAuthenticatedAction(
            (id) =>
                User_GroupService.CreateGroup(id, title)
            );
        }

        public JsonResult AddToGroup(long REL_Id1, string REL_ObjectType1, long[] ids = null)
        {
            if (ids == null) return Json("no ids");
            return JsonTryAuthenticatedAction(
            (id) =>
                User_GroupService.AddToGroup(id, REL_Id1, ids)
            );
        }

        protected override System.Linq.IQueryable<User_GroupObject> Filter(System.Linq.IQueryable<User_GroupObject> _src)
        {
            _src = _src.OrderBy(s => s.Title);
            return base.Filter(_src);
        }

    }
}
