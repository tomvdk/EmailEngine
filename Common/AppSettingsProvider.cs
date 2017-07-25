using System.Configuration;

namespace EmailEngine.Common
{
    public class AppSettingsProvider : IAppSettingsProvider
    {
        public string EmailFrom => ConfigurationManager.AppSettings["EmailFrom"];
        public string InputFile => ConfigurationManager.AppSettings["InputFile"];
    }
}
