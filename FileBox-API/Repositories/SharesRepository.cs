using Dapper;
using FileBox_API.Interfaces;
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
    }
}
