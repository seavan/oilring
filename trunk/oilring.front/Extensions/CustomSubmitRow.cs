using System.Web.Mvc;

namespace System
{
    public class CustomSubmitRow : CustomTagControl<CustomSubmitRow>, IControl
    {
        public string Wrap { get; set; }

        public CustomSubmitRow(HtmlHelper htmlHelper)
            : base(htmlHelper)
        {
        }

        public override void OpenTag()
        {
            Writer.WriteLine("<dd class='but show'>");
        }

        public CustomSubmitRow Button(string _text, string _tClass, string _command, string _class = "")
        {
            Writer.WriteLine("<input type='button' value='{0}' class='ibutton {2} {1}' rel='{3}'/>", _text, _class, _tClass, _command);
            return this;
        }

        public CustomSubmitRow Submit(string _text, string _tClass, string _command, string _class = "")
        {
            Writer.WriteLine("<input type='submit' value='{0}' class='ibutton {2} {1}' rel='{3}'/>", _text, _class, _tClass, _command);
            return this;
        }

        public CustomSubmitRow ObjectEditToolbar()
        {
            Button("Предварительный просмотр", "_preview _blank _presave", "preview");
            Submit("Опубликовать", "_publish _presave", "publish");
            Submit("Удалить", "_delete", "delete");
            Submit("Сохранить в черновиках", "_publish draft _ajax", "draft");
            return this;
        }

        public override void CloseTag()
        {
            Writer.WriteLine("</dd>");
        }
    }
}