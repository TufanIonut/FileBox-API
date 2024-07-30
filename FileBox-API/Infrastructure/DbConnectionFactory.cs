using FileBox_API.Interfaces;
using Microsoft.AspNetCore.Connections;
using System.Data;
using System.Data.SqlClient;

namespace FileBox_API.Infrastructure
{
    public class DbConnectionFactory : IDbConnectionFactory
    {
        IConfiguration _configuration;
        public DbConnectionFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IDbConnection ConnectToDataBase()
        {
            var conectionString = _configuration.GetConnectionString("DefaultConnection");
            IDbConnection connection = new SqlConnection(conectionString);
            connection.Open();
            return connection;
        }
    }
}
