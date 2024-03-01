using LearnHub.Identity.IdentityService.Abstract;
using LearnHub.Identity.IdentityService.Implement;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace LearnHub.Identity
{
    public static class IdentityServicesRegistration
    {
        public static void ConfigureIdentityServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddMediatR(Assembly.GetExecutingAssembly());


            services.AddScoped<IUserService,UserService>();

        }
    }
}
