using System.Security.Principal;
using admin.db;
using System.Collections.Generic;
using Common.Security;
namespace System.Web
{
    public class UserPrincipal : IPrincipal
    {
        public UserObject CurrentUser { get; private set; }
        public List<string> Roles { get; private set; }

        public UserPrincipal(IIdentity _identity, UserObject _user, List<string> _roles)
        {
            CurrentUser = _user;
            Roles = _roles;
            Identity = _identity;
        }

        public IIdentity Identity
        {
            get;
            private set;
        }

        public bool IsInRole(string _role)
        {
            return Roles.Contains(_role);
        }

        public bool isAdministrator()
        {
            return IsInRole(BasicRoles.ADMIN);
        }
        public bool isModerator()
        {
            return IsInRole(BasicRoles.MODER);
        }
    }
}