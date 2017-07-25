using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Threading.Tasks;

namespace EmailEngine.Email
{
    public class AsyncEmailSender : IAsyncEmailSender
    {
        public async Task SendAll(ICollection<MailMessage> mailMessages)
        {
            using (var client = new SmtpClient())
            {
                var interval = 2000; // 2000 ms delay
                await mailMessages.ForEachWithDelay(mailMessage => Task.Run(() =>
                    {
                        Console.WriteLine("sending " + mailMessage + " @ " + DateTime.Now);
                        client.Send(mailMessage);
                        Console.WriteLine(mailMessage + "sent @ " + DateTime.Now);
                    }
                ), interval);
            }
        }
    }
}
