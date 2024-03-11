using System.Reflection;
using Microsoft.Extensions.DependencyInjection; 

namespace LearnHub.Email
{
    public static class IEmailServices
    {
        public static void ConfigureEmailServices(this IServiceCollection services)
        {
            services.AddScoped<LocalMailService>();

        }
    }
}
