using LearnHub.SMS.Model;
using LearnHub.SMS.services;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using System.Reflection;

namespace LearnHub.SMS
{
    public static  class SMSConfiguration
    {


        public static void ConfigureSMS(this IServiceCollection services)
        {

            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddScoped<ISMSService, SMSService>();
        }
    }
}
