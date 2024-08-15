using FileBox_API.Infrastructure;
using FileBox_API.Interfaces;
using FileBox_API.Repositories;
using FileBox_API.Services;

namespace FileBox_API
{
    public static class MyConfigServiceCollection
    {
        public static IServiceCollection AddMyDependencyGroup(
             this IServiceCollection services)
        {
            //User 
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();
            //-----------------------------
            //WordToPdf
            services.AddScoped<IWordToPdfService, WordToPdfService>();
            //-----------------------------
            //Infrastructure 
            services.AddScoped<IDbConnectionFactory, DbConnectionFactory>();
            //-----------------------------
            //Files
            services.AddScoped<IFilesRepository, FilesRepository>();
            services.AddScoped<IFilesService, FilesService>();

            //-----------------------------
            //Folders
            services.AddScoped<IFolderRepository, FolderRepository>();
            
            return services;
        }
    }
}
