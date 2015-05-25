	
/*
	User controller code generation
	Author: Samvel Avanesov 
	Mailto: seavan@gmail.com
	Table alias:	PrivateMessage
	File name: 	PrivateMessage.controller.cs
*/
			
using System;
using System.ComponentModel.DataAnnotations;
using admin.db;
using System.Web.Mvc;

namespace Notamedia.Oilring
{
    public class PrivateMessageController : admin.web.common.PrivateMessageController
    {
        public JsonResult AddMessage([Bind]PrivateMessageItemObject _object)
        {
            DataServiceLocator.PrivateMessageService.ReplyTo(_object.REL_Id, Params.CurrentUserId, _object.Text);
            return Json("success");
        }
    }
}	
