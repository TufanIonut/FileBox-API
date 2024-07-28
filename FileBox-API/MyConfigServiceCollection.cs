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
            //-----------------------------
            //WordToPdf
            services.AddScoped<IWordToPdfService, WordToPdfService>();
            //-----------------------------
            return services;
        }
    }
}
