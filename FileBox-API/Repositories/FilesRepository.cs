using Dapper;
using FileBox_API.Interfaces;
using FileBox_API.Requests;
using System.Data;

namespace FileBox_API.Repositories
{
    public class FilesRepository : IFilesRepository
    {
        private readonly IDbConnectionFactory _dbConnectionFactory;
        public FilesRepository(IDbConnectionFactory dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory;
        } 
        public async Task<int> AddFileAsyncRepo(AddFile_Request addFileRequest)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@IdUser", addFileRequest.IdUser);
            parameters.Add("@FileName", addFileRequest.FileName);
            parameters.Add("@FileType", addFileRequest.FileType);
            parameters.Add("@FileLink", addFileRequest.FileLink);
            parameters.Add("@Date", addFileRequest.Date);
            parameters.Add("@Success", dbType: DbType.Int32, direction: ParameterDirection.Output);
            try
            {
                using (var connection = _dbConnectionFactory.ConnectToDataBase())
                {
                    await connection.ExecuteAsync("sp_AddFile", parameters, commandType: CommandType.StoredProcedure);

                    return parameters.Get<int>("@Success");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
