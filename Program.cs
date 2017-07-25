using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EmailEngine.Reader;
using EmailEngine.Email;
using System.Net.Mail;
using EmailEngine.Common;

namespace EmailEngine
{
    class Program
    {
        static void Main(string[] args)
        {
            var appSettingsProvider = new AppSettingsProvider();
            var emailSender= new AsyncEmailSender();
            var inputRecordReader = new InputRecordReader(appSettingsProvider.InputFile);
            var emailComposer = new EmailComposer(appSettingsProvider.EmailFrom);

            IList<InputRecord> inputRecords = inputRecordReader.ReadAllInputRecords();

            ICollection<MailMessage> mailMessages = emailComposer.ComposeAll(inputRecords);

            Task.Run(async () => { await emailSender.SendAll(mailMessages); }).GetAwaiter().GetResult();

            Console.ReadLine();
        }
    }
}
