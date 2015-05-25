using System.Web;
using System.Web.Mvc;

namespace Web.Common.Security
{
	public class Authorize403Attribute : AuthorizeAttribute
	{
		protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
		{
			throw new HttpException(403, "Forbidden");
		}
	}
}
