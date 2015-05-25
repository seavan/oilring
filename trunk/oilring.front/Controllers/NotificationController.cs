	
/*
	User controller code generation
	Author: Samvel Avanesov 
	Mailto: seavan@gmail.com
	Table alias:	Notification
	File name: 	Notification.controller.cs
*/
			
using System;
using System.ComponentModel.DataAnnotations;
using admin.db;
using System.Web.Mvc;

namespace Notamedia.Oilring
{
    public class NotificationController : admin.web.common.NotificationController
    {
        public JsonResult AcceptNotification(long REL_Id1, string REL_ObjectType1)
        {
            return JsonTryAuthenticatedAction((id) => NotificationService.ConfirmNotification(REL_Id1, id));
        }

        public JsonResult RejectNotification(long REL_Id1, string REL_ObjectType1)
        {
            return JsonTryAuthenticatedAction((id) => NotificationService.RejectNotification(REL_Id1, id));
        }

        public JsonResult DeleteNotification(long REL_Id1, string REL_ObjectType1)
        {
            return JsonTryAuthenticatedAction((id) => NotificationService.DeleteNotification(REL_Id1, id));
        }

        public JsonResult RevokeNotification(long REL_Id1, string REL_ObjectType1)
        {
            return JsonTryAuthenticatedAction((id) => NotificationService.RevokeNotification(REL_Id1, id));
        }
    }
}	
