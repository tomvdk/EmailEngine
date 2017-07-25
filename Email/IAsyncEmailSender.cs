using System.Collections.Generic;
using System.Net.Mail;
using System.Threading.Tasks;

namespace EmailEngine.Email
{
    public interface IAsyncEmailSender
    {
        Task SendAll(ICollection<MailMessage> mailMessages);
    }
}