﻿using Dapper;
using FileBox_API.Interfaces;
using FileBox_API.Requests;
using FileBox_API.Responses;
using System.Data;
using System.IO;

namespace FileBox_API.Repositories
{
    public class FilesRepository : IFilesRepository
    {
        private readonly IDbConnectionFactory _dbConnectionFactory;
        public FilesRepository(IDbConnectionFactory dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory;
        } 
        //-----------------------------------------------------------------------------------
        //AddFile Method 
        public async Task<int> AddFileAsyncRepo(AddFile_Request addFileRequest)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@IdUser", addFileRequest.IdUser);
            parameters.Add("@FileName", addFileRequest.FileName);
            parameters.Add("@FileExtension", addFileRequest.FileType);
            parameters.Add("@FileLink", addFileRequest.FileLink);
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
        //-----------------------------------------------------------------------------------
        //GetFiles Method
        public async Task<IEnumerable<GetFiles_Response>> GetFilesAsyncRepo(int idUser)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@IdUser", idUser);
            try
            {
                using (var connection = _dbConnectionFactory.ConnectToDataBase())
                {
                    return await connection.QueryAsync<GetFiles_Response>("sp_GetFiles", parameters, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        //-----------------------------------------------------------------------------------
        //GetDeletedFiles Method
        public async Task<IEnumerable<GetFiles_Response>> GetDeletedFilesAsyncRepo(int idUser)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@IdUser", idUser);
            try
            {
                using (var connection = _dbConnectionFactory.ConnectToDataBase())
                {
                    return await connection.QueryAsync<GetFiles_Response>("sp_GetDeletedFiles", parameters, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        //-----------------------------------------------------------------------------------
        //GetSafeFiles Method
        public async Task<IEnumerable<GetFiles_Response>> GetSafeFilesAsyncRepo(int idUser)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@IdUser", idUser);
            try
            {
                using (var connection = _dbConnectionFactory.ConnectToDataBase())
                {
                    return await connection.QueryAsync<GetFiles_Response>("sp_GetSafeFiles", parameters, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        //-----------------------------------------------------------------------------------
        //RenameFile Method
        public async Task<int> RenameFileAsyncRepo(RenameFile_Request renameFileRequest, string currentFileName)
        {
            
            var parameters = new DynamicParameters();
            parameters.Add("@IdUser", renameFileRequest.IdUser);
            parameters.Add("@CurrentFileName", currentFileName);
            parameters.Add("@NewFileName", renameFileRequest.NewFileName);
            parameters.Add("NewPath", renameFileRequest.Path);
            parameters.Add("@Success", dbType: DbType.Int32, direction: ParameterDirection.Output);
            try
            {
                using (var connection = _dbConnectionFactory.ConnectToDataBase())
                {
                    await connection.ExecuteAsync("sp_RenameFile", parameters, commandType: CommandType.StoredProcedure);

                    return parameters.Get<int>("@Success");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        //-----------------------------------------------------------------------------------
        //SoftDeleteFile Method
        public async Task<int> SoftDeleteFileAsyncRepo(int idFile)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@IdFile", idFile);
            parameters.Add("@Success", dbType: DbType.Int32, direction: ParameterDirection.Output);
            try
            {
                using (var connection = _dbConnectionFactory.ConnectToDataBase())
                {
                    await connection.ExecuteAsync("sp_SoftDeleteFile", parameters, commandType: CommandType.StoredProcedure);

                    return parameters.Get<int>("@Success");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        //-----------------------------------------------------------------------------------
        //AddFileToSafe Method  
        public async Task<int> AddFileToSafeAsyncRepo(int idFile)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@IdFile", idFile);
            parameters.Add("@Success", dbType: DbType.Int32, direction: ParameterDirection.Output);
            try
            {
                using (var connection = _dbConnectionFactory.ConnectToDataBase())
                {
                    await connection.ExecuteAsync("sp_AddToSafe", parameters, commandType: CommandType.StoredProcedure);

                    return parameters.Get<int>("@Success");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        //-----------------------------------------------------------------------------------
        //RemoveFileFromSafe Method
        public async Task<int> RemoveFileFromSafeAsyncRepo(int idFile)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@IdFile", idFile);
            parameters.Add("@Success", dbType: DbType.Int32, direction: ParameterDirection.Output);
            try
            {
                using (var connection = _dbConnectionFactory.ConnectToDataBase())
                {
                    await connection.ExecuteAsync("sp_RemoveFileFromSafe", parameters, commandType: CommandType.StoredProcedure);

                    return parameters.Get<int>("@Success");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        //-----------------------------------------------------------------------------------
        //RemoveFileFromBin Method
        public async Task<int> RemoveFileFromBinAsyncRepo(int idFile)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@IdFile", idFile);
            parameters.Add("@Success", dbType: DbType.Int32, direction: ParameterDirection.Output);
            try
            {
                using (var connection = _dbConnectionFactory.ConnectToDataBase())
                {
                    await connection.ExecuteAsync("sp_RemoveFileFromBin", parameters, commandType: CommandType.StoredProcedure);

                    return parameters.Get<int>("@Success");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        //-----------------------------------------------------------------------------------
        //DeleteFile Method
        public async Task<int> DeleteFileAsyncRepo(string path)
        {
            path= path.Replace(@"\\", @"\");

            var parameters = new DynamicParameters();
            parameters.Add("@Path", path);
            parameters.Add("@Success", dbType: DbType.Int32, direction: ParameterDirection.Output);
            try
            {
                using (var connection = _dbConnectionFactory.ConnectToDataBase())
                {
                    await connection.ExecuteAsync("sp_DeleteFile", parameters, commandType: CommandType.StoredProcedure);

                    return parameters.Get<int>("@Success");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        //-----------------------------------------------------------------------------------
        //RenameBatch Method

    }
}
