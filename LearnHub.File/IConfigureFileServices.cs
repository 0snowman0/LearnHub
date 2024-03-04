using LearnHub.File.Implement;
using LearnHub.File.Interface;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace LearnHub.File
{
    public static class IConfigureFileServices
    {
        public static void ConfigureFileServices(this IServiceCollection services)
        {

            services.AddScoped<IFileService, FileService>();
        }
    }
}
