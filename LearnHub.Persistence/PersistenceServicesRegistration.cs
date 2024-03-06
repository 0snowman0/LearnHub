using LearnHub.Application.Contracts.comment;
using LearnHub.Application.Contracts.Course;
using LearnHub.Application.Contracts.FinancialSector;
using LearnHub.Application.Contracts.Generic;
using LearnHub.Application.Contracts.payment;
using LearnHub.Application.Contracts.Support.SupportAdmin;
using LearnHub.Application.Contracts.Support.SupportStudent;
using LearnHub.Application.Contracts.Tools;
using LearnHub.Identity.IdentityService.Abstract;
using LearnHub.Persistence.Repositories.comment;
using LearnHub.Persistence.Repositories.course;
using LearnHub.Persistence.Repositories.FinancialSector;
using LearnHub.Persistence.Repositories.Generic;
using LearnHub.Persistence.Repositories.Identity;
using LearnHub.Persistence.Repositories.payment;
using LearnHub.Persistence.Repositories.Support;
using LearnHub.Persistence.Tools;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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



            services.AddScoped<ICoursePpurchased, CoursePpurchased_Rep>();

            services.AddScoped<IComment, Comment_Rep>();

            services.AddScoped<ICourse, Course_Rep>();



            services.AddScoped<IHelpFunction, HelpFunction_Rep>();



            services.AddScoped<Ipayment, Payment_Rep>();



            services.AddScoped<ISupportStudent , SupportStudent_Rep>();

            services.AddScoped<ISupportAdmin , SupportAdmin_Rep>();

            services.AddScoped<ISubCourse, SubCourse_Rep>();



            services.AddScoped<Iuser, User_Rep>();



            return services;
        }
    }
}
