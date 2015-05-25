using Notamedia.Oilring.Database.DataAccess;
using Notamedia.Oilring.Database;
namespace admin.db
{
    public partial class OrganizationObject : IOrgItem, ITitleable, IUserEnhancable
    {
        public string SmallAvatar
        {
            get { return "pic10.jpg"; }
        }

        public string NormalAvatar
        {
            get { return "gerb.gif"; }
        }

        public System.Linq.Expressions.Expression<System.Func<object, string>> GetTitleExpr()
        {
            return (obj) => ((OrganizationObject) obj).Title; 
        }

        public bool PSEUDO_IsUserFavourite { get; set; }

        public int PSEUDO_NewCommentCount { get; set; }

        public int AUTO_CommentCount { get; set; }

        public long? Owner_User_ID { get; set; }
    }
}