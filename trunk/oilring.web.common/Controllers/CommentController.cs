	
/*
	Common controller code generation
	Author: Samvel Avanesov 
	Mailto: seavan@gmail.com
	Table alias:	Comment
	File name: 	Comment.controller.cs
*/
			

using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using Notamedia.Oilring.Database;
using admin.db;
using System.Collections.Generic;
using System.Web.Mvc;

namespace admin.web.common
{
    public partial class CommentController : OilringBaseUniversalController<CommentObject>
    {


        public int SortNested(List<CommentObject> _result, IQueryable<CommentObject> _q, long _parentId, int level = 0, int index = 0)
        {
            var list = _q.Where(s => s.Parent_Comment_ID == _parentId).ToArray();
            _result.InsertRange(index, list);

            foreach (var i in list)
            {
                ++index;
                i.Level = level;
                index = SortNested(_result, _q, i.Id, level + 1, index);
            }
            return index;
        }

        public override void Prepare(CommentObject _item)
        {
            base.Prepare(_item);
            if (_item.Id == 0)
            {
                _item.CreationDate = DateTime.Now;
                _item.PublicationDate = DateTime.Now;
                _item.ModificationDate = DateTime.Now;
            }
        }

        public ActionResult AddComment([Bind]CommentObject _object, string _command = "")
        {
            _object.Owner_User_ID = Params.CurrentUserId;
            InsertNew(_object);
            return RedirectToParent(_object.REL_Id, _object.REL_ObjectType);
        }


        public ActionResult AddWidget()
        {
            var p = Params;
            return View(new CommentObject() { Parent_Comment_ID = p.ParentID, REL_ObjectType = p.REL_ObjectType, REL_Id = p.REL_ObjectID });
        }
    }
}	
