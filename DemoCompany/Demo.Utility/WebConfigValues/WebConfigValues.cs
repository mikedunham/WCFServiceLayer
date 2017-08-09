using System.Configuration;

namespace Demo.Utility.WebConfigValues
{
    public class WebConfigValues : IConnectionStringConfig
    {
        public string this[string key] => ConfigurationManager.ConnectionStrings[key].ConnectionString;
    }
}
