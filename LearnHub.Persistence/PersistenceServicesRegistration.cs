using LearnHub.Application.Contracts.comment;
using LearnHub.Application.Contracts.Course;
using LearnHub.Application.Contracts.Generic;
using LearnHub.Application.Contracts.Support.SupportAdmin;
using LearnHub.Application.Contracts.Support.SupportStudent;
using LearnHub.Identity.IdentityService.Abstract;
using LearnHub.Identity.IdentityService.Implement;
using LearnHub.Persistence.Repositories.comment;
using LearnHub.Persistence.Repositories.course;
using LearnHub.Persistence.Repositories.Generic;
using LearnHub.Persistence.Repositories.Identity;
using LearnHub.Persistence.Repositories.Support;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Windows.Input;

namespace LearnHub.Persistence
{
    public static class PersistenceServicesRegistration
    {
        public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services,
            IConfiguration configuration)
        {

            services.AddDbContext<Context_En>(options =>
            {
                options.UseSqlServer(configuration
                    .GetConnectionString("DefaultConnection"));
            });

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            services.AddScoped<Iuser, User_Rep>();

            services.AddScoped<ISupportStudent , SupportStudent_Rep>();

            services.AddScoped<ISupportAdmin , SupportAdmin_Rep>();

            services.AddScoped<IComment , Comment_Rep>();

            services.AddScoped<ICourse , Course_Rep>();

            return services;
        }
    }
}
