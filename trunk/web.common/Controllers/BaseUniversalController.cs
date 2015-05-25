using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Telerik.Web.Mvc;
using Database.Entities;
using Database.Interfaces;
using Common;
using Database.Extensions;
using Web.Common;
using Database;
using Web.Common.Validation;
using Web.Common.Security;
using Web.Common.Models;
using Web.Common.Filters;
using Web.Common.Modules;
using Web.Common.Extensions;
using Common.Security;

namespace Web.Common.Controllers
{
    public abstract class BaseUniversalController<_T> : BasicController 
        where _T : class, IDatabaseEntity, new()
    {
        #region Nested type: RequestsAutoComplete
        public class RequestsAutoComplete
        {
            public string Additional { get; set; }
            public string Icon { get; set; }
            public string Id { get; set; }
            public string Title { get; set; }
        }
        #endregion

        protected BaseViewData<_T> m_BaseViewData;

        protected FilterList<IDatabaseEntity> m_PreFilterList = new FilterList<IDatabaseEntity>();

        protected IDataService<_T> m_Service;

        public MessageStacker ValidationMessageStacker = new MessageStacker();

        public BaseUniversalController()
        {
            // TODO: Зачем?
            ViewData["BaseController"] = GetType().Name.Replace("Controller", "");
            /*if( Request.IsAuthenticated )
            {
                ViewData["CurrentUser"] = ((UserPrincipal) User).CurrentUser;
            }*/

            ValidateRequest = false;

            Behaviour = new DataServiceBehavior<IDatabaseEntity>();

            //Behaviour.OnlyPublished = true;

        }

        [AcceptVerbs(HttpVerbs.Post)]
        [GridAction]
        public ActionResult _Delete()
        {
            var id = int.Parse(Request["Id"].Split(',')[0]);
            var data = GetSingle(id);
            if (data != null)
            {
                Delete(data);
            }
            return View(new GridModel(GetAll()));
        }


        [GridAction]
        public ActionResult _DeleteServer(int id)
        {
            var data = GetSingle(id);
            if (data != null)
            {
                Delete(data);
            }
            return RedirectToAction("Index");
        }


        [AcceptVerbs(HttpVerbs.Post)]
        [GridAction]
        public ActionResult _Insert([Bind(Exclude = "Id")] _T _item)
        {
            if (ModelState.IsValid)
            {
                InsertNew(_item);
            }
            return View(new GridModel(GetAll()));
        }


        [GridAction]
        public virtual ActionResult _Select()
        {
            var items = GetAll();
            return View(new GridModel(
                            items
                            ));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [GridAction]
        public ActionResult _Update([Bind] _T item)
        {
            if (ModelState.IsValid)
            {
                Prepare(item);
                Service.Update(item);
            }
            return View(new GridModel(GetAll()));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [GridAction]
        public ActionResult _UpdateServer(int id)
        {
            if (ModelState.IsValid)
            {
                var updating = GetSingle(id);
                UpdateModel(updating);
                Prepare(updating);
                Service.Update(updating);
            }
            return View("Index", GetAll());
        }

        // TODO
        public ActionResult AdminCreateDraft()
        {
            var item = Create();
            InitDraft(item);
            //            item.Published = true;
            //            item.Approved = true;
            Service.Insert(item);
            return RedirectToAction("Single", new { id = item.Id });
        }

        protected virtual ActionResult BaseAction(ModuleParams _params = null, bool _enhance = true)
        {
            var moduleParams = _params != null ? _params : GetModuleParams();
            var vn = moduleParams.ViewName;
            var res = GetCachedEnhancedUltraItems(moduleParams, _enhance);
            return String.IsNullOrEmpty(vn) ? View(res) : View(vn, res);
        }

        public virtual _T Create()
        {
            return Service.CreateItem();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [GridAction]
        [Authorize403(Roles = BasicRoles.USER)]
        public virtual ActionResult Delete(_T _item)
        {
            Service.Delete(_item);
            return View(new GridModel(GetAll()));
        }

        [Authorize403(Roles = BasicRoles.USER)]
        public ActionResult DeleteObject(long Id)
        {
            Service.Delete(Service.GetById(Id));
            return RedirectToAction("List");
        }

        [ValidateInput(false)]
        [Authorize403(Roles = BasicRoles.USER)]
        public ActionResult Edit(long id)
        {
            var f = Service.GetById(id);
            if (Request.HttpMethod == "POST")
            {
                if (CustomTryUpdateModel(f))
                {
                    Service.Update(f);
                    RedirectToAction("Single", new { id });
                }
            }
            return View(f);
        }

        protected virtual IQueryable<_T> Filter(IQueryable<_T> _src)
        {
            return _src;
        }

        public virtual IEnumerable<_T> GetAll()
        {
            return Filter(Service.GetAll());
            //return GetTable().AsEnumerable();
        }

        public IQueryable<_A> GetUntypedCachedEnhancedUltraItems<_A>(ModuleParams _moduleParams, bool _enhance = true)
        {
            var moduleParams = _moduleParams;
            var ViewName = moduleParams.ViewName;
            var cacheSignature = m_PreFilterList.GetCacheSignature(moduleParams);
            var res =
                this.GetOrStore(ViewName,
                                typeof(_T),
                                () => { return m_PreFilterList.GetConverted(moduleParams); }, cacheSignature);

            return res.Cast<_A>();
        }


        public IQueryable<_T> GetCachedEnhancedUltraItems(ModuleParams _moduleParams, bool _enhance = true)
        {
            var moduleParams = _moduleParams;
            var ViewName = moduleParams.ViewName;
            var cacheSignature = m_PreFilterList.GetCacheSignature(moduleParams);
            var res =
                this.GetOrStore(ViewName,
                                typeof(_T),
                                () => { return m_PreFilterList.GetConverted(moduleParams); }, cacheSignature);

            return Filter(res.Cast<_T>());
        }

        public abstract ModuleParams GetModuleParams();

        protected abstract IDataService<_T> GetService();

        public virtual _T GetSingle(long _id)
        {
            return Service.GetById(_id);
        }

        public JsonResult GetValidationMessagesJson()
        {
            return Json(ValidationMessageStacker.List);
        }

        [GridAction]
        public ActionResult Index()
        {
            return View(GetAll());
        }

        public ActionResult List()
        {
            return View();
        }

        public ActionResult ListItems()
        {
            return BaseAction();
        }


        public ActionResult ListRandom()
        {
            var p = GetModuleParams();
            var res =
                this.GetOrStore(p.ViewName,
                                typeof(_T),
                                () =>
                                {
                                    var q = GetAll().OrderByDescending(s => s.Id).AsQueryable();
                                    q = q.Take(20).AsQueryable();

                                    return q.ToArray();
                                }, p.REL_ObjectID, p.Relation, p.REL_ObjectType);
            var rnd = new Random();
            res =
                res.Where(s => !s.Id.Equals(p.REL_ObjectID)).OrderBy(n => (rnd.Next())).Take((int)p.PageSize).ToArray();

            return String.IsNullOrEmpty(p.ViewName) ? View(res) : View(p.ViewName, res);
        }

        public ActionResult ListWidget()
        {
            return ListItems();
        }

        public ActionResult Pager(int PageSize = 0, string ViewName = "Pager", int Order = 0, int Page = 0)
        {
            var moduleParams = GetModuleParams();
            var cacheSignature = m_PreFilterList.GetCacheSignature(moduleParams);
            long rowsCount = (int)this.GetOrStore("ListItemsCount",
                                                   typeof(_T),
                                                   () =>
                                                   {
                                                       // hack to force to display all rows
                                                       moduleParams.PageSize = 0;
                                                       return
                                                           (object)
                                                           m_PreFilterList.GetFilteredCount(moduleParams);
                                                   }, cacheSignature, "Count");
            long pgCount = 0;

            if (PageSize > 0)
            {
                pgCount = (rowsCount / PageSize) + (rowsCount % PageSize > 0 ? 1 : 0);
            }

            var model = new PagerModel(rowsCount, pgCount, Page, moduleParams.ModuleId, typeof(_T));

            return String.IsNullOrEmpty(ViewName) ? View(model) : View(ViewName, model);
        }

        [GridAction]
        public ActionResult Popup()
        {
            return View(GetAll());
        }

        public ActionResult Preview(long Id)
        {
            return RedirectToAction("Single", new { Id });
        }

        public ActionResult PreviewWidget(long Id)
        {
            return View("SingleWidget", Service.GetById(Id));
        }

        public ActionResult Publish(long Id)
        {
            var item = GetSingle(Id);
            item.Published = true;
            item.Approved = true;
            Service.Update(item);
            return RedirectToAction("Single", new { Id });
        }

        public ActionResult RedirectToParent(long _objectId, string _objectType)
        {
            return RedirectToAction("Single", Mapper.INST.MapToTypeName(_objectType), new { Id = _objectId });
        }


        public ActionResult RelatedEditWidget()
        {
            return ListItems();
        }

        [ValidateInput(false)]
        //[Authorize403(Roles = Roles.USER)]
        public ActionResult SaveAjax(long Id, string _command, FormCollection collection)
        {
            var entry = Service.GetById(Id);

            if (!CustomTryUpdateModel(entry, false))
            {
                if (Request.IsAjaxRequest())
                {
                    return GetValidationMessagesJson();
                }
                else
                {
                    return RedirectToAction("Edit", new { Id = Id });
                }
            }

            Service.Update(entry);
            UploadFields(entry);
            CheckRelations(entry);
            Prepare(entry);

            switch (_command)
            {
                case "delete":
                    return RedirectToAction("DeleteObject", new { Id });
                case "preview":
                    return RedirectToAction("Preview", new { Id });
                case "draft":
                    //                    RedirectToAction("Draft");
                    break;
                case "publish":
                    return RedirectToAction("Publish", new { Id });
            }
            return Content("success");
        }

        public ActionResult SearchResult()
        {
            return View();
        }

        [ValidateInput(false)]
        public abstract ActionResult Single(long id);

        public ActionResult SingleWidget(long id)
        {
            var p = GetModuleParams();
            p.Id = id;

            var vn = p.ViewName;
            Behaviour.OnlyApproved = false;
            Behaviour.OnlyPublished = false;

            var q = id > 0 ? GetCachedEnhancedUltraItems(p).FirstOrDefault() : null;

            return String.IsNullOrEmpty(vn) ? View(q) : View(vn, q);
        }

        public bool CustomTryUpdateModel(_T _model, bool _updateRelations = true)
        {
            WebModelValidator validator = new WebModelValidator();
            var res = validator.TryUpdate(_model, ValidationMessageStacker);
            if (res && _updateRelations)
            {
                UploadFields(_model);
                CheckRelations(_model);
                Prepare(_model);
            }
            
            ViewData.SetValidation(ValidationMessageStacker);
            return res;
        }

        public bool CustomTryUpdateGeneralModel<_X>(_X _model)
        {
            WebModelValidator validator = new WebModelValidator();
            var res = validator.TryUpdate(_model, ValidationMessageStacker);
            ViewData.SetValidation(ValidationMessageStacker);
            return res;
        }


        public ActionResult UploadField()
        {
            var file = Request.Files[0];
            // Some browsers send file names with full path. This needs to be stripped.
            var fileName = Path.GetFileName(file.FileName);
            var physicalPath = Path.Combine(Server.MapPath("~/Content/temp"), fileName);

            // The files are not actually saved in this demo
            file.SaveAs(physicalPath);

            return Content("");
        }


        public void CheckRelations(_T _item)
        {
            var rs = Service.GetRegisteredRelations();
            foreach (var r in rs)
            {
                var v = Request.Form[r];

                if (v != null)
                {
                    JavaScriptSerializer serializer = new JavaScriptSerializer();
                    var relationInfo = serializer.Deserialize<PreRelationInfo>(v);
                    var ctype = Mapper.INST.GetObjectType(relationInfo.ObjectType.ToLower());
                    var relationInfoType = typeof(RelationInfo<>).MakeGenericType(ctype);

                    relationInfo = (PreRelationInfo)serializer.Deserialize(v, relationInfoType);

                    var existingRels = Service.GetAllRelations(r, _item);

                    // delete all that do not match
                    var toDelete =
                        existingRels.Where(
                            s =>
                            relationInfo.Relations.Where(n => n.Id.Equals(s.Id) && n.ObjectType.Equals(n.ObjectType)).
                                Count() == 0);

                    // create all that are new
                    var toCreate =
                        relationInfo.Relations.Where(
                            s => /* important */
                            (s.Id > 0) &&
                            existingRels.Where(n => n.Id.Equals(s.Id) && n.ObjectType.Equals(n.ObjectType)).Count() == 0);

                    foreach (var c in toDelete)
                    {
                        Service.DeleteRelation(r, _item, c.Id, c.ObjectType);
                    }

                    var items = relationInfo.GetCreations();

                    foreach (var databaseEntity in items)
                    {
                        var entity = DataStore.Add(databaseEntity, _item);

                        if (!typeof(IManyToOne).IsAssignableFrom(entity.GetType()))
                        {
                            Service.CreateRelation(r, _item, entity.Id, entity.ObjectType);
                        }
                    }

                    foreach (var c in toCreate)
                    {
                        Service.CreateRelation(r, _item, c.Id, c.ObjectType);
                    }
                }
            }
        }

        public virtual void InitDraft(_T _item)
        {
            _item.Approved = false;
            _item.Published = false;
        }

        public virtual void InsertNew(_T _item)
        {
            Prepare(_item);
            Service.Insert(_item);
        }

        public virtual void Prepare(_T _item)
        {
        }

        public void UploadFields(_T _item)
        {
            return;
            for (int i = 0; i < Request.Files.AllKeys.Length; ++i)
            {
                var field = Request.Files.AllKeys[i];
                var file = Request.Files[field];
                var fname = Guid.NewGuid().ToString() + ".png";
                var path1 = Server.MapPath("~/Content/temp");
                var path2 = Server.MapPath("~") + "\\..\\community\\Content\\images";

                file.SaveAs(Path.Combine(path1, fname));
                file.SaveAs(Path.Combine(path2, fname));

                var prop = _item.GetType().GetProperty(field);
                prop.SetValue(_item, fname, new object[] { });
            }
        }

        public BaseViewData<_T> BaseViewData
        {
            get
            {
                if (m_BaseViewData == null)
                {
                    m_BaseViewData = new BaseViewData<_T>(ViewData);
                }

                return m_BaseViewData;
            }
        }

        public DataServiceBehavior<IDatabaseEntity> Behaviour { get; set; }

        public ModuleParams Params
        {
            get { return GetModuleParams(); }
        }

        public IDataService<_T> Service
        {
            get
            {
                if (m_Service == null)
                {
                    m_Service = GetService();
                }

                return m_Service;
            }
        }

        public JsonResult JsonTryAuthenticatedAction(Action<long> _callback)
        {
            if (Request.IsAuthenticated)
            {
                _callback(GetModuleParams().CurrentUserId);
                return Json("success");
            }
            else
            {
                return Json("no auth");
            }            
        }


    }
}