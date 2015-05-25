using System.Web.Mvc;
using System.Web.Mvc.Html;
using Notamedia.Oilring.Database.DataAccess;
using Database.Entities;

namespace System
{
    public class CustomEntityForm : CustomForm
    {
        private IDatabaseEntity m_Entity = null;
        public CustomEntityForm(HtmlHelper _helper, IDatabaseEntity _entity) : base(_helper)
        {
            m_Entity = _entity;
        }

        public override void OpenTag()
        {
            base.OpenTag();
            Writer.WriteLine(Helper.Hidden("Id", m_Entity.Id));
            Writer.WriteLine(Helper.Hidden("ObjectType", m_Entity.ObjectType.Trim()));
            Writer.WriteLine(Helper.Hidden("_command", ""));
        }
    }
}