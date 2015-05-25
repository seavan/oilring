
/*
    Services code generation
    Author: Samvel Avanesov 
    Mailto: seavan@gmail.com
    Table alias:	MessageTemplate
    File name: 	MessageTemplate.service.cs
*/


using System;
using System.Linq;
using System.Data.Linq;
using System.ComponentModel.DataAnnotations;
using Notamedia.Oilring.Database;
using System.Collections.Generic;
using Notamedia.Oilring.Database.DataAccess;
using System.Net.Mail;
using System.Text.RegularExpressions;
namespace admin.db
{
    public partial class MessageTemplateService : IMessageTemplateService
    {
        protected override void Init()
        {
            base.Init();
            var appSettings = GetAppSettings();
            M_MAIL_GATEWAY = appSettings["mail_gateway"];
            M_PORT = int.Parse(appSettings["mail_gateway_port"]);
            M_FROM = appSettings["mail_gateway_from"];
        }

        protected string M_FROM = "";
        protected int M_PORT = 25;
        protected string M_MAIL_GATEWAY = "";

        #region IMessageTemplateService Members

        public string SendEmail(string _type, string _email, SortedList<string, string> _parameters, bool _send = true)
        {
            var eml = GetAll().Where(s => s.Alias.Equals(_type)).SingleOrDefault();
            if (eml == null) return null;

            var text = eml.Text;
            var subj = eml.Title;
            var notify = eml.NotificationText;

            var regex = new Regex(@"\{(\w+)\}");
            MatchEvaluator replacer = delegate(Match _match) {
                                                   var n = _match.Groups[1].Value;
                                                   if (_parameters.IndexOfKey(n) != -1)
                                                       return _parameters[n];
                                                   else return _match.Value;
                                               };
            text = regex.Replace(text, replacer);
            subj = regex.Replace(subj, replacer);

            if (notify != null)
            {
                notify = regex.Replace(notify, replacer);
            }

            if( _send ) SendActualEmail(subj, text, _email);

            return notify;
        }

        #endregion


        public void SendActualEmail(string _subject, string _text, string _to)
        {
            var addr = _to;
            var from = M_FROM;
            var text = _text;

            MailMessage email = new MailMessage(from, addr, _subject, text);

            email.IsBodyHtml = true;

            var sc = new System.Net.Mail.SmtpClient(M_MAIL_GATEWAY, M_PORT);
            sc.Credentials = null;
            sc.UseDefaultCredentials = false;
            sc.EnableSsl = false;

            sc.Send(email);
        }
    }
}
