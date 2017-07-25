namespace EmailEngine.Common
{

    public interface IAppSettingsProvider
    {
        string InputFile { get; }
        string EmailFrom { get; }
    }
}
