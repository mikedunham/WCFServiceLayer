using System.Configuration;

namespace Demo.Utility.WebConfigValues
{
    public class AppSettingsConfig : IAppSettingsConfig
    {
        public string this[string key] => ConfigurationManager.AppSettings[key];

        public static class DatabaseKeyString
        {
            public static string KeyName
            {
                get { return "DatabaseKeyName"; }
            }
        }
    }
}
