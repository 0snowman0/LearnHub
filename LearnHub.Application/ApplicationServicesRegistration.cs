using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using ZarinPal.Class;

namespace LearnHub.Application
{
    public static class ApplicationServicesRegistration
    {
        public static void ConfigureApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddMediatR(Assembly.GetExecutingAssembly());



            services.AddScoped<Payment, ZarinPal.Class.Payment>();

            services.AddSingleton<ZarinPal.Class.Authority>();

            services.AddTransient<ZarinPal.Class.Transactions>();

        }
    }
}
