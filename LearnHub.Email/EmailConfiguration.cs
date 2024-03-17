using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace LearnHub.Email
{
    public static class EmailConfiguration
    {
        public static void ConfigureEmail(this IServiceCollection services)
        {

            services.AddMediatR(Assembly.GetExecutingAssembly());


            services.AddScoped<IEmailService, EmailService>();
        }
    }
}
