using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace LearnHub.Email
{
    public static class EmailConfiguration
    {
        public static void ConfigureEmail(this IServiceCollection services)
        {
            services.AddScoped<IEmailService, EmailService>();
        }
    }
}
