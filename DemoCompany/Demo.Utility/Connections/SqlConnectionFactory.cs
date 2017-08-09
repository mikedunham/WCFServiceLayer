using System;
using System.Data;
using System.Data.Common;
using Demo.Utility.WebConfigValues;

namespace Demo.Utility.Connections
{
    public interface ISqlConnectionFactory
    {
        IDbConnection CreateConnection();
        DbProviderFactory GetProviderFactory();
    }

    public class SqlConnectionFactory : ISqlConnectionFactory
    {
        private readonly DbProviderFactory _providerFactory;
        private readonly IAppSettingsConfig _appSettings;
        private readonly IConnectionStringConfig _connectionStrings;
        private readonly string _connectionStringNameAppKey;



        private static DbConnection CreateConnection(DbProviderFactory factory, string connectionString)
        {
            var connection = factory.CreateConnection();
            if (connection == null) throw new NullReferenceException("Factory unable to create connection check your dbprovider settings in the web.config");
            connection.ConnectionString = connectionString;
            return connection;
        }

        public SqlConnectionFactory(IAppSettingsConfig appSettings, IConnectionStringConfig connectionStrings)
        {
            _providerFactory = DbProviderFactories.GetFactory("System.Data.SqlClient");
            _appSettings = appSettings;
            _connectionStrings = connectionStrings;
            _connectionStringNameAppKey = AppSettingsConfig.DatabaseKeyString.KeyName;
        }

        public IDbConnection CreateConnection()
        {
            return CreateConnection(_providerFactory, _connectionStrings[_appSettings[_connectionStringNameAppKey]]);
        }

        public DbProviderFactory GetProviderFactory()
        {
            throw new NotImplementedException();
        }
    }
}
