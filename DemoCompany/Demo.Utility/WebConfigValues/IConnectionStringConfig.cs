namespace Demo.Utility.WebConfigValues
{
    public interface IConnectionStringConfig
    {
        string this[string key] { get; }
    }
}