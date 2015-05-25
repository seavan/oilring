	
/*
	User controller code generation
	Author: Samvel Avanesov 
	Mailto: seavan@gmail.com
	Table alias:	Tag
	File name: 	Tag.controller.cs
*/
			
using System;
using System.ComponentModel.DataAnnotations;
using admin.db;
using System.Linq;
using System.Web.Script.Serialization;
using System.Web.Mvc;
using System.Collections.Generic;
using admin.web.common;
using Notamedia.Oilring.Database.DataAccess;
using Notamedia.Oilring.Database;
using Database.Entities;
using Web.Common.Filters;

namespace Notamedia.Oilring
{
    public class TagController : admin.web.common.TagController
    {
        public TagController()
        {
            m_PreFilterList.RegisterPreFilter(
                new BasicFilter<IDatabaseEntity>(
                    GetType().Name + "_ByTagRubricList",
                    (_params, _q) =>
                    {
                        var ids = _params.GetUserRubricFilter().Split(';').Select(s => long.Parse(s)).ToArray();
                        var t = Service.FilterByRelated<Rubric>("TagRubrics", ids, _q);
                        return t;
                    },
                    (_params) => { return !String.IsNullOrEmpty(_params.GetUserRubricFilter()); },
                    (_params) => { return new object[] { _params.UserFilter, _params.GetUserRubricFilter() }; }
                    )
                );
        }

        protected ITagService m_TagService;

        private ITagService TagService
        {
            get
            {
                if (m_TagService == null)
                {
                    m_TagService = GetService() as ITagService;
                }

                return m_TagService;
            }
        }

        public string AutoCompleteSearch(string searchString)
        {
            var tags = TagService.GetAllTags(searchString).Select(u => new RequestsAutoComplete { Id = u.Id.ToString(), Title = u.Text, Additional = "", Icon = "" });
            var jsonSerializer = new JavaScriptSerializer();
            return jsonSerializer.Serialize(tags);
        }

        public ActionResult GetHtmlItemList(long searchId)
        {
            var tag = TagService.GetById(searchId);
            if (tag != null) return PartialView("RelatedListWidgetForEdit", new List<TagObject> { tag });

            return null;
        }
        
        public ActionResult SearchHtmlItemList(string searchName)
        {
            var tag = TagService.GetAll().Where(t=>t.Text== searchName).FirstOrDefault();
            List<string> tagName = TagService.GetAll().Select(t => t.Text).ToList();


            if (tag == null) 
            {
                tag = new TagObject
                {
                    Text = searchName,
                    Id = 0,
                    ObjectType = "tag"
                };
            }

            return PartialView("RelatedListWidgetForEdit", new List<TagObject> {tag});
        }

        public override ActionResult Single(long id)
        {
            var results = TagService.GetRelated("Tag", id, "tag");
            return base.Single(id);
        }
    }
}	
