using Dapper;
using FileBox_API.Interfaces;
using FileBox_API.Requests;
using System.Data;

namespace FileBox_API.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IDbConnectionFactory _dbConnectionFactory;
        public UserRepository (IDbConnectionFactory dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory;
        }
        public async Task<int> LoginAsyncRepo(Login_Request loginRequest)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Email", loginRequest.Email);
            parameters.Add("@Password", loginRequest.Password);
            parameters.Add("@IdUser", dbType: DbType.Int32, direction: ParameterDirection.Output);
            try
            {
                using (var connection = _dbConnectionFactory.ConnectToDataBase())
                {
                    await connection.ExecuteAsync("sp_Login", parameters, commandType: CommandType.StoredProcedure);

                    return parameters.Get<int>("@IdUser");
                }
            }
            catch (Exception) 
            {

                throw;
            } 
        }
        public async Task<int> RegisterAsyncRepo(Register_Request registerRequest)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Email", registerRequest.Email);
            parameters.Add("@Password", registerRequest.Password);
            parameters.Add("@Username", registerRequest.Username);
            parameters.Add("@IdUser", dbType: DbType.Int32, direction: ParameterDirection.Output);
            try
            {
                using (var connection = _dbConnectionFactory.ConnectToDataBase())
                {
                    await connection.ExecuteAsync("sp_Register", parameters, commandType: CommandType.StoredProcedure);

                    return parameters.Get<int>("@IdUser");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
