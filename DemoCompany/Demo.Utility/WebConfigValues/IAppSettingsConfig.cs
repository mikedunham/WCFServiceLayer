namespace Demo.Utility.WebConfigValues
{
    public interface IAppSettingsConfig
    {
        string this[string key] { get; }
    }
}