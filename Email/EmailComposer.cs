using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net.Mail;
using System.Web.UI.WebControls;

namespace EmailEngine.Email
{
    public class EmailComposer : IEmailComposer
    {
        private readonly string _fromEmail;
        public EmailComposer(string fromEmail)
        {
            _fromEmail = fromEmail;
        }

        public MailMessage Compose(InputRecord inputRecord)
        {
            MailDefinition md = new MailDefinition();
            md.From = _fromEmail;
            md.IsBodyHtml = true;
            md.Subject = "Test of MailDefinition";

            ListDictionary replacements = new ListDictionary();
            replacements.Add("{name}", inputRecord.Name);
            replacements.Add("{imageThumbnailUri}", inputRecord.ThumbnailUri.ToString());
            replacements.Add("{videoUri}", inputRecord.VideoUri);

            string body = @"<div>Hello {name},<br/><a href=""{videoUri}""><img width=""300px"" height=""300px"" src=""{imageThumbnailUri}""></img></div>";

            return md.CreateMailMessage(inputRecord.EmailTo, replacements, body, new System.Web.UI.Control());
        }

        public IList<MailMessage> ComposeAll(IList<InputRecord> inputRecords)
        {
            IList<MailMessage> mailMessages = new List<MailMessage>();

            foreach (var inputRecord in inputRecords)
            {
                try
                {
                    mailMessages.Add(this.Compose(inputRecord));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return mailMessages;
        }
    }
}
