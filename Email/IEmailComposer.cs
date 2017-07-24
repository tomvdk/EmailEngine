using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;

namespace EmailEngine.Email
{
    public interface IEmailComposer
    {
        MailMessage Compose(InputRecord inputRecord);
        IList<MailMessage> ComposeAll(IList<InputRecord> inputRecords);
    }
}
