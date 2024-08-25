using Dapper;
using FileBox_API.Interfaces;
using FileBox_API.Requests;
using FileBox_API.Responses;
using System.Data;

namespace FileBox_API.Repositories
{
    public class SharesRepository : IShareRepository
    {
        private readonly IDbConnectionFactory _dbConnectionFactory;
        public SharesRepository(IDbConnectionFactory dbConnectionFactory)
        {
                _dbConnectionFactory = dbConnectionFactory;
        }

        public async Task<IEnumerable<Users_Response>> GetUsersAasyncRepo(int idUser)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@ExcludedUserId", idUser);
            using (var connection = _dbConnectionFactory.ConnectToDataBase())
            {
                return await connection.QueryAsync<Users_Response>("sp_GetAllUsers", parameters, commandType: CommandType.StoredProcedure);
            }
        }
        public async Task <int> InsertSharedFileAsyncRepo(Share_Request shareRequest)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@IdFile", shareRequest.IdFile);
            parameters.Add("@IdSender", shareRequest.IdSender);            
            parameters.Add("@IdReceiver", shareRequest.IdReceiver);
            parameters.Add("@Success", dbType: DbType.Int32, direction: ParameterDirection.Output);
            using (var connection = _dbConnectionFactory.ConnectToDataBase())
            {
                 await connection.ExecuteAsync("sp_InsertSharedFile", parameters, commandType: CommandType.StoredProcedure);
                return parameters.Get<int>("@Success");
            }
        }
        public async Task<IEnumerable<Statistics_Response>> GetStatisticsForApplicationAsyncRepo()
        {
        using (var connection = _dbConnectionFactory.ConnectToDataBase())
        {
             var result = await connection.QueryAsync<Statistics_Response>("GetApplicationStatistics", commandType: CommandType.StoredProcedure);
                return result;
            }
            
        }
        public async Task<IEnumerable<GetSharedFiles_Response>> GetSharedFilesAsyncRepo(int IdUser)
        {
            var parameters = new DynamicParameters();
            parameters.Add ("@ReceiverId", IdUser);
            using(var connection = _dbConnectionFactory.ConnectToDataBase())
            {

                return await connection.QueryAsync<GetSharedFiles_Response>("sp_GetSharedFiles", parameters, commandType: CommandType.StoredProcedure);

            }
        }
        public async Task<int> DeleteSharedFile(int IdSharedFile)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@IdSharedFile", IdSharedFile);
            parameters.Add("@Success", dbType: DbType.Int32, direction: ParameterDirection.Output);
            using (var connection = _dbConnectionFactory.ConnectToDataBase())
            {
                var result = await connection.ExecuteAsync("sp_DeleteSharedFile", parameters, commandType: CommandType.StoredProcedure);
                return parameters.Get<int>("@Success");
            }
        }
    }
}
