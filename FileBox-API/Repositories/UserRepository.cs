using Dapper;
using FileBox_API.Interfaces;
using FileBox_API.Requests;
using FileBox_API.Responses;
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
        public async Task<int> AddProfilePictureAsyncRepo(Add_UpdatePP_Request addProfilePictureRequest)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@IdUser", addProfilePictureRequest.IdUser);
            parameters.Add("@ProfilePicture", addProfilePictureRequest.ProfilePicture);
            parameters.Add("@Success", dbType: DbType.Int32, direction: ParameterDirection.Output);
            try
            {
                using (var connection = _dbConnectionFactory.ConnectToDataBase())
                {
                    await connection.ExecuteAsync("sp_AddOrUpdateProfilePicture", parameters, commandType: CommandType.StoredProcedure);

                    return parameters.Get<int>("@Success");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<int> AddSafePasswordAsyncRepo(Add_UpdateSafePass_Request addSafePasswordRequest)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@IdUser", addSafePasswordRequest.IdUser);
            parameters.Add("@SafePassword", addSafePasswordRequest.SafePassword);
            parameters.Add("@Success", dbType: DbType.Int32, direction: ParameterDirection.Output);
            try
            {
                using (var connection = _dbConnectionFactory.ConnectToDataBase())
                {
                    await connection.ExecuteAsync("sp_AddOrUpdateSafePassword", parameters, commandType: CommandType.StoredProcedure);

                    return parameters.Get<int>("@Success");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<int> LoginSafePasswordAsyncRepo(LoginSafePass_Request loginSafePasswordRequest)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@IdUser", loginSafePasswordRequest.IdUser);
            parameters.Add("@SafePassword", loginSafePasswordRequest.safePassword);
            parameters.Add("@IsMatch", dbType: DbType.Int32, direction: ParameterDirection.Output);
            try
            {
                using (var connection = _dbConnectionFactory.ConnectToDataBase())
                {
                    await connection.ExecuteAsync("sp_LoginSafePassword", parameters, commandType: CommandType.StoredProcedure);

                    return parameters.Get<int>("@IsMatch");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<GetUserDetails_Response> GetUserDetailsAsyncRepo(int idUser)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@IdUser", idUser);
            try
            {
                using (var connection = _dbConnectionFactory.ConnectToDataBase())
                {
                    return await connection.QueryFirstAsync<GetUserDetails_Response>("sp_GetUserDetails", parameters, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
