using Dapper;
using FileBox_API.Interfaces;
using FileBox_API.Requests;
using FileBox_API.Responses;
using System.Data;

namespace FileBox_API.Repositories
{
    public class FolderRepository : IFolderRepository
    {
        private readonly IDbConnectionFactory _dbConnectionFactory;
        public FolderRepository(IDbConnectionFactory dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory;
        }
        public async Task<int> AddFolderAsyncRepo(AddFolder_Request addFolderRequest)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@IdUser", addFolderRequest.IdUser);
            parameters.Add("@FolderName", addFolderRequest.FolderName);
            parameters.Add("@Success", dbType: DbType.Int32, direction: ParameterDirection.Output);
            try
            {
                using (var connection = _dbConnectionFactory.ConnectToDataBase())
                {
                    await connection.ExecuteAsync("sp_AddFolder", parameters, commandType: CommandType.StoredProcedure);

                    return parameters.Get<int>("@Success");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<IEnumerable<GetFolders_Response>> GetFoldersAsyncRepo(int idUser)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@IdUser", idUser);
            try
            {
                using (var connection = _dbConnectionFactory.ConnectToDataBase())
                {
                    var result = await connection.QueryAsync<GetFolders_Response>("sp_GetFolders", parameters, commandType: CommandType.StoredProcedure);
                    return result;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<int> DeleteFolderAsyncRepo(int idFolder)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@IdFolder", idFolder);
            parameters.Add("@Success", dbType: DbType.Int32, direction: ParameterDirection.Output);
            try
            {
                using (var connection = _dbConnectionFactory.ConnectToDataBase())
                {
                    await connection.ExecuteAsync("sp_DeleteFolderAndFiles", parameters, commandType: CommandType.StoredProcedure);

                    return parameters.Get<int>("@Success");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<int> RenameFolderAsyncRepo(RenameFolder_Request renameFolderRequest)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@IdFolder", renameFolderRequest.IdFolder);
            parameters.Add("@NewFolderName", renameFolderRequest.FolderName);          
            parameters.Add("@Success", dbType: DbType.Int32, direction: ParameterDirection.Output);
            try
            {
                using (var connection = _dbConnectionFactory.ConnectToDataBase())
                {
                    await connection.ExecuteAsync("sp_RenameFolder", parameters, commandType: CommandType.StoredProcedure);

                    return parameters.Get<int>("@Success");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<int> AddFileInFolderAsyncRepo(AddFileInFolder_Request addFileInFolderRequest)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@IdFolder", addFileInFolderRequest.IdFolder);
            parameters.Add("@IdFile", addFileInFolderRequest.IdFile); 
            parameters.Add("@Success", dbType: DbType.Int32, direction: ParameterDirection.Output);
            try
            {
                using (var connection = _dbConnectionFactory.ConnectToDataBase())
                {
                    await connection.ExecuteAsync("sp_AddFileToFolder", parameters, commandType: CommandType.StoredProcedure);

                    return parameters.Get<int>("@Success");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<IEnumerable<GetFiles_Response>> GetFilesAsyncInFolderAsyncRepo(int idFolder)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@IdFolder", idFolder);
            try
            {
                using (var connection = _dbConnectionFactory.ConnectToDataBase())
                {
                    var result = await connection.QueryAsync<GetFiles_Response>("sp_GetFilesInFolder", parameters, commandType: CommandType.StoredProcedure);
                    return result;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        
    }
}
