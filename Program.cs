using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EmailEngine.Reader;
using EmailEngine.Email;
using System.Net.Mail;

namespace EmailEngine
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputRecordReader = new InputRecordReader(@"inputdata.csv");
            var emailComposer = new EmailComposer("tvandekerkhof@hotmail.com");
            Task.Run(async () =>
            {
                IList<InputRecord> inputRecords = inputRecordReader.ReadAllInputRecords();

                ICollection<MailMessage> mailMessages = emailComposer.ComposeAll(inputRecords);

                SmtpClient client = new SmtpClient();

                var interval = 2000; // 2000 ms delay
                await mailMessages.ForEachWithDelay(mailMessage => Task.Run(() =>
                {
                    Console.WriteLine("sending " +mailMessage + " @ " + DateTime.Now);
                    client.Send(mailMessage);
                    Console.WriteLine(mailMessage + "sent @ " + DateTime.Now);
                }
                ), interval);
            }).GetAwaiter().GetResult();

            Console.ReadLine();
        }
    }
}
