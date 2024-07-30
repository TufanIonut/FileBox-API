using System.Data;

namespace FileBox_API.Interfaces
{
    public interface IDbConnectionFactory
    {
        IDbConnection ConnectToDataBase();

    }
}