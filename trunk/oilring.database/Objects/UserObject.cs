using Notamedia.Oilring.Database.DataAccess;
using System;
using System.Web;
using System.Security.Cryptography;
using System.Text;
using Web.Common.Validation;
using Web.Common.Metadata;
namespace admin.db
{
    [Serializable]
    public partial class UserObject : IDefaultPhotoable, IUserItem, IFriendEnhancable
    {
        public string DisplayName
        {
            get { return FirstName + " " + LastName;  }
        }

        public string DisplayNameReverse
        {
            get { return LastName + " " + FirstName; }
        }


        public string DisplayNameBr
        {
            get { return FirstName + "<br/>" + LastName; }
        }


        public string SmallAvatar
        {
            get { return AUTO_DefaultPhoto_Guid != null ? String.Format("{0}/{1}/{2}", ObjectType.Trim(), Id, AUTO_DefaultPhoto_Guid + ".small.png") : "pic4.jpg";  }
        }
        public string NormalAvatar
        {
            get { return AUTO_DefaultPhoto_Guid != null ? String.Format("{0}/{1}/{2}", ObjectType.Trim(), Id, AUTO_DefaultPhoto_Guid + ".mid.png") : "pic12.jpg"; }
        }

        public bool IsActivate
        {
            get { return !Activation_guid.HasValue; }
        }

        public string NewPassword { get; set; }
        public string NewPasswordRepeat { get; set; }
        public string OldPassword { get; set; }

        #region IFriendEnhancable Members


        public bool PSEUDO_IsInFriends
        {
            get;
            set; 
        }

        public bool PSEUDO_IsFriendRequestSent
        {
            get;
            set;
        }

        public bool PSEUDO_Self
        {
            get;
            set;
        }

        #endregion


        public static string CalculateHash(string _password)
        {
            StringBuilder strHash = new StringBuilder();

            foreach (byte b in new MD5CryptoServiceProvider().ComputeHash(Encoding.Default.GetBytes(_password)))
            {
                strHash.Append(b.ToString("x2"));
            }
            return strHash.ToString();
        }

        public bool IsPasswordCorrect(string _pass)
        {
            return Password.Equals(CalculateHash(_pass));
        }

        public bool IsAgeVisible 
        {
            get 
            {
                return
                    (Options_ShowAge == 0)
                    || ((Options_ShowAge == 1) && PSEUDO_IsInFriends);
            }
        }

        public bool IsContactsVisible
        {
            get
            {
                return
                    (Options_ShowContacts == 0)
                    || ((Options_ShowContacts == 1) && PSEUDO_IsInFriends);
            }
        }

        public bool IsInterestsVisible
        {
            get
            {
                return
                    (Options_ShowInterests == 0)
                    || ((Options_ShowInterests == 1) && PSEUDO_IsInFriends);
            }
        }

        public bool IsEducationVisible
        {
            get
            {
                return
                    (Options_ShowEducations == 0)
                    || ((Options_ShowEducations == 1) && PSEUDO_IsInFriends);
            }
        }

        public bool IsJobsVisible
        {
            get
            {
                return
                    (Options_ShowJobs == 0)
                    || ((Options_ShowJobs == 1) && PSEUDO_IsInFriends);
            }
        }

        public bool IsMiddleNameVisible
        {
            get
            {
                return
                    (Options_ShowMiddleName == 0)
                    || ((Options_ShowMiddleName == 1) && PSEUDO_IsInFriends);
            }
        }

    }

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
    public class PasswordValidator : Attribute, ICustomValidator
    {
        public string[] FieldNames { get; set; }

        #region ICustomValidator Members

        public bool IsValid(System.Reflection.PropertyInfo _prop, object _parentObject, object _value, ICustomValueProvider _valueProvider)
        {
            UserObject cu = null;
            if (HttpContext.Current.Request.IsAuthenticated)
            {
                cu = ((UserPrincipal)HttpContext.Current.User).CurrentUser;
            }
            return cu.IsPasswordCorrect(_value.ToString());

        }

        public string GetMessage(System.Reflection.PropertyInfo _prop, object _parentObject, object _value, ICustomValueProvider _valueProvider)
        {
            return "Неправильный пароль";
        }

        #endregion
    }
}