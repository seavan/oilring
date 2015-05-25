	
/*
	User controller code generation
	Author: Samvel Avanesov 
	Mailto: seavan@gmail.com
	Table alias:	User
	File name: 	User.controller.cs
*/
			
using System;
using System.ComponentModel.DataAnnotations;
using admin.db;
using System.Linq;
using System.Web.Script.Serialization;
using System.Web.Mvc;
using System.Web;
using Elmah;
using Notamedia.Oilring.Database.DataAccess;
using Notamedia.Oilring.Community.Common;
using System.Drawing;
using System.Drawing.Imaging;
using System.Collections.Generic;
using admin.web.common;
using Database.Entities;

namespace Notamedia.Oilring
{
    public class UserController : admin.web.common.UserController
    {
        public UserController()
        {
            Behaviour.OnlyPublished = true;
            Behaviour.OnlyApproved = true;

            m_PreFilterList.RegisterPreFilter
                <UserObject, IUserItem>(new ByLetterUserFilter<IDatabaseEntity>());

        }

        protected IUserService m_UserService;

        private IUserService UserService
        {
            get
            {
                if (m_UserService == null)
                {
                    m_UserService = GetService() as IUserService;
                }

                return m_UserService;
            }
        }

        public ActionResult InternalPage(long id)
        {
            var p = GetModuleParams();
            if (!Request.IsAuthenticated || p.CurrentUserId != id)
            {
                return RedirectToAction("403");
            }
            return View();
        }

        public ActionResult Activity(long id)
        {
            return View();
        }

        public ActionResult Friends(long id)
        {
            return View();
        }

        public ActionResult FriendsEdit(long id)
        {
            return InternalPage(id);
        }

        public ActionResult Options(long id)
        {
            return InternalPage(id);
        }

        public ActionResult Notifications(long id)
        {
            return InternalPage(id);
        }

        public ActionResult PrivateMessages(long id)
        {
            return InternalPage(id);
        }


        public override ActionResult Single(long id = 0)
        {
/*            if (Request.IsAuthenticated)
            {
                var p = GetModuleParams();
                if ((p.CurrentUserId == id) || (id == 0))
                {
                    return RedirectToAction("Edit", new { id = id });
                }
            } */
            return base.Single(id);
        }

		public string AutoCompleteSearch(string searchString)
		{
		    var users = UserService.GetAllUsers(searchString).Select(u=> new RequestsAutoComplete{ Id = u.Id.ToString(), Title = u.LastName + " " + u.FirstName, Additional = "", Icon = u.SmallAvatar});
            var jsonSerializer = new JavaScriptSerializer();
            return jsonSerializer.Serialize(users);
		}

        public ActionResult GetHtmlItemList(long searchId)
        {
            var user = UserService.GetById(searchId);
            if (user != null) return PartialView("ListItemForEdit", user);

            return null;
        }
        public ActionResult SearchHtmlItemList(string searchName)
        {
            return null;
        }

        [HttpGet]
        public ActionResult SignIn(string activation_message = "")
        {
            ViewData["activation_message"] = activation_message;
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult SignIn(AuthenticationModel model, string UrlReturn = null)
        {
            if (model == null) RedirectToAction("SignIn");

            if (ModelState.IsValid)
            {
                string result;
                HttpCookie cookie;
                if (UserService.SignIn(model.Login, model.Password,  model.RememberMe, out result, out cookie))
                {
                    ViewData["Cookie"] = cookie;

                    HttpCookie userRubricCookie = Request.Cookies["UserSelectedRubrics"];
                    if (userRubricCookie != null)
                    {
                        var jsonSerializer = new JavaScriptSerializer();
                        List<long> IDs = jsonSerializer.Deserialize<List<long>>(userRubricCookie.Value);
                        DataServiceLocator.RubricService.SetUserRubrics(IDs, UserService.GetIsLoginUser());

                        userRubricCookie.Expires = DateTime.Now.AddDays(-1);
                        userRubricCookie.Domain = Request.ServerVariables["HTTP_HOST"];
                        Response.Cookies.Add(userRubricCookie);
                    }

                    if (model.isAjax)
                    {
                        return PartialView("HeaderAuthBlock", UserService.GetIsLoginUser());
                    }

                    ViewData["ReturnUrl"] = String.IsNullOrEmpty(UrlReturn) ? "/" : UrlReturn;

                    return View(model);
                }
                else
                {
                    ModelState.AddModelError("AdditionalError", result);
                }
            }
            model.isValid = false;
            if (model.isAjax)
            {
                return PartialView("HeaderNoAuthBlock", model);
            }
            return View("SignIn", model);
        }

        public ActionResult SignOut()
        {
            UserService.SignOut();
            ViewData["SignOut"] = true;
            return PartialView("HeaderNoAuthBlock", new AuthenticationModel());
        }

        public ActionResult Register()
        {
            return View();
        }

        public bool CheckHasEmail(string _email)
        {
            return UserService.GetAll().Any(u => u.UserLogin == _email);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Register(RegistrationModel model)
        {
            if (!model.AgreementConfirm)
            {
                ModelState.AddModelError("AgreementConfirm", "Вы должны подтвердить свое согласие");
            }
            if (model.Password != model.PasswordConfirm)
            {
                ModelState.AddModelError("PasswordConfirm", "Пароли должны совпадать");
            }
            if(CheckHasEmail(model.EMail))
            {
                ModelState.AddModelError("UserLogin", "Такой EMail уже есть в системе");
            }
            if (ModelState.IsValid)
            {
                
                try
                {
                    UserService.RegisterUser(model);
                    return View("RegisterFinish");
                }
                catch (System.Exception _e)
                {
                    ErrorSignal.FromCurrentContext().Raise(_e);
                }
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult RecoveryPassword()
        {
            return View();
        }
        [HttpPost]
        public ActionResult RecoveryPassword(RecoveryPassword model)
        {
            if(ModelState.IsValid)
            {
                string result = "";
                if (ValidateRecoverPassword(model.EMail, model.Captcha, out result))
                {
                    if (UserService.RecoveryPassword(model.EMail))
                    {
                        return View("RecoveryPasswordGo");
                    }

                    ModelState.AddModelError("AdditionalError", "Произошла ошибка сервера.");
                }
                else
                {
                    ModelState.AddModelError("AdditionalError", result);
                }
                
            }

            model.Captcha = string.Empty;
            return View(model);
        }

        [HttpGet]
        public ActionResult RecoveryPasswordConfirm(long Id, string CheckLink)
        {
            string result = "";
            UserService.RecoveryPasswordConfirm(Id, CheckLink, out result);
            ViewData["notifiText"] = result;
            return View("RecoveryPasswordGo");
        }

        #region CAPTHCA
        public class CaptchaImageResult : ActionResult
        {
            public override void ExecuteResult(ControllerContext context)
            {
                string guid = context.HttpContext.Request.QueryString["guid"];
                CaptchaImage ci = CaptchaImage.GetCachedCaptcha(guid);

                if (String.IsNullOrEmpty(guid) || ci == null)
                {
                    context.HttpContext.Response.StatusCode = 404;
                    context.HttpContext.Response.StatusDescription = "Not Found";
                    context.HttpContext.ApplicationInstance.CompleteRequest();
                    return;
                }

                // Запись изображения в выходной поток HTTP как массива байтов                
                using (Bitmap b = ci.RenderImage())
                {
                    b.Save(context.HttpContext.Response.OutputStream, ImageFormat.Jpeg);
                }

                context.HttpContext.Response.ContentType = "image/jpeg";
                context.HttpContext.Response.StatusCode = 200;
                context.HttpContext.Response.StatusDescription = "OK";
                context.HttpContext.ApplicationInstance.CompleteRequest();
            }
        }

        public CaptchaImageResult ImageCaptcha()
        {
            return new CaptchaImageResult();
        }

        public ActionResult GetNewImageCaptcha()
        {
            return PartialView("Captcha");
        }

        /// <summary>
        /// Проверка пользователя по логину (e-mail) и CAPTHCA тексту перед восстановлением пароля
        /// </summary>
        /// <param name="_email">логин (e-mail)</param>
        /// <param name="_capthca">CAPTHCA</param>
        /// <param name="_message">сообщение об ошибке</param>
        /// <returns>результат проверки</returns>
        private bool ValidateRecoverPassword(string _email, string _capthca, out string _message)
        {
            _message = null;
            var user = UserService.GetAll().Where(u => u.UserLogin == _email).FirstOrDefault();

            if (user == null)
            {
                _message = "Электронный адрес не зарегистирован в системе";
                return false;
            }

            if (!user.IsActivate)
            {
                _message = "Ваш аккаунт не активирован";
                return false;
            }

            if (string.IsNullOrEmpty(_capthca))
            {
                _message = "Введите текст";
                return false;
            }

            string guid = Request.Form["captcha-guid"];
            if (String.IsNullOrEmpty(guid))
            {
                _message = "Ошибка сервера. Перегрузите страницу";
                return false;
            }

            CaptchaImage image = CaptchaImage.GetCachedCaptcha(guid);
            string expectedValue = image == null ? String.Empty : image.Text;
            System.Web.HttpContext.Current.Cache.Remove(guid);

            if (String.IsNullOrEmpty(expectedValue) || !String.Equals(_capthca, expectedValue, StringComparison.OrdinalIgnoreCase))
            {
                _message = "Вы ввели неверный текст";
                return false;
            }

            return true;
        }
        #endregion

        public JsonResult SetFavourite(long REL_Id1, string REL_ObjectType1, bool set = true)
        {
            if (Request.IsAuthenticated)
            {
                UserService.SetFavourites(GetModuleParams().CurrentUserId, new DummyEntity(REL_Id1, REL_ObjectType1),
                                          set);
                return Json("success");
            }
            else
            {
                return Json("no auth");
            }
        }

        public JsonResult AddToFriends(long REL_Id1)
        {
            if (Request.IsAuthenticated)
            {
                var obj1 = Service.GetById(GetModuleParams().CurrentUserId);
                var obj2 = Service.GetById(REL_Id1);
                UserService.AddFriendRequest(obj1, obj2);
                DataServiceLocator.NotificationService.AddToFriendsRequest(
                    obj1,
                    obj2);
                return Json("success");
            }
            else
            {
                return Json("no auth");
            }
        }

        public JsonResult UseSelectedRubrics()
        {
            if (Request.IsAuthenticated)
            {
                var obj1 = Service.GetById(GetModuleParams().CurrentUserId);
                obj1.UseSelectedRubrics = true;
                obj1.OneRubricSelection = null;
                UserService.Update(obj1);
                return Json("success");
            }
            else
            {
                return Json("no auth");
            }
        }

        public JsonResult UseOneRubric(long rubricId)
        {
            if (Request.IsAuthenticated)
            {
                var obj1 = Service.GetById(GetModuleParams().CurrentUserId);
                obj1.UseSelectedRubrics = null;
                obj1.OneRubricSelection = rubricId;
                UserService.Update(obj1);
                return Json("success");
            }
            else
            {
                return Json("no auth");
            }
        }

        public JsonResult UseAllMaterials()
        {
            if (Request.IsAuthenticated)
            {
                var obj1 = Service.GetById(GetModuleParams().CurrentUserId);
                obj1.UseSelectedRubrics = null;
                obj1.OneRubricSelection = null;
                UserService.Update(obj1);
                return Json("success");
            }
            else
            {
                return Json("no auth");
            }
        }

        public JsonResult JoinEvent(long REL_Id1, string REL_ObjectType1)
        {
            if (Request.IsAuthenticated)
            {
                var obj1 = Service.GetById(GetModuleParams().CurrentUserId);
                var obj2 = DataStore.Resolve(REL_Id1, REL_ObjectType1);
                if (obj2 != null)
                {
                    UserService.JoinEventRequest(obj1, obj2);
                    return Json("success");
                }
                return Json("no resolve");
            }
            else
            {
                return Json("no auth");
            }
        }


        public ActionResult Activate(string guid)
        {
            if (UserService.ActivateUser(guid))
            {
                return RedirectToAction("SignIn", "User", new { activation_message = "Аккаунт успешно активирован" });
            }
            return RedirectToAction("SignIn", "User", new { activation_message = "Аккаунт уже был активирован, либо введен неверный активационный ключ" });
        }

        public JsonResult AddMessageThread()
        {
            var _object = DataServiceLocator.PrivateMessageService.CreateItem();
            if (!CustomTryUpdateGeneralModel(_object))
            {
                if (Request.IsAjaxRequest())
                {
                    return GetValidationMessagesJson();
                }
            }
            var uid = Params.CurrentUserId;
            DataServiceLocator.PrivateMessageService.CreateThread(_object.REL_ReceiverUserId, uid, 
                                                                  _object.AUTO_Subject, _object.AUTO_Text);
            return Json("success");

        }

        public JsonResult DeleteMessages(long[] ids = null)
        {
            if (ids == null) return Json("false");
            foreach (var id in ids)
            {
                DataServiceLocator.PrivateMessageService.Delete(DataServiceLocator.PrivateMessageService.GetById(id));
            }
            return Json("success");
        }

    }
}	
