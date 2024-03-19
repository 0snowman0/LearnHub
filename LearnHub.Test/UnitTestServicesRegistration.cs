using FluentValidation;
using LearnHub.Application.Dto.comment.command;
using LearnHub.Application.Dto.comment.common;
using LearnHub.Application.Dto.Course.course.command;
using LearnHub.Application.Dto.Course.course.common;
using LearnHub.Application.Dto.Course.subcourse.command;
using LearnHub.Application.Dto.Course.subcourse.common;
using LearnHub.Application.Dto.Permistion.command;
using LearnHub.Application.Dto.Permistion.common;
using LearnHub.Application.Dto.profile.Student.command;
using LearnHub.Application.Dto.profile.Teacher.command;
using LearnHub.Application.Dto.store.command;
using LearnHub.Application.Dto.Support.SupportAdmin.command;
using LearnHub.Application.Dto.Support.SupportAdmin.common;
using LearnHub.Application.Dto.Support.SupportStudent.command;
using LearnHub.Application.Dto.Support.SupportStudent.common;
using LearnHub.Application.Validation.comment.command;
using LearnHub.Application.Validation.comment.common;
using LearnHub.Application.Validation.Course.course.command;
using LearnHub.Application.Validation.Course.course.common;
using LearnHub.Application.Validation.Course.subcourse.command;
using LearnHub.Application.Validation.Course.subcourse.common;
using LearnHub.Application.Validation.Permistion.command;
using LearnHub.Application.Validation.Permistion.common;
using LearnHub.Application.Validation.profile.Student.command;
using LearnHub.Application.Validation.profile.Teacher.command;
using LearnHub.Application.Validation.store.command;
using LearnHub.Application.Validation.Support.SupportAdmin.command;
using LearnHub.Application.Validation.Support.SupportAdmin.common;
using LearnHub.Application.Validation.Support.SupportStudent.command;
using LearnHub.Application.Validation.Support.SupportStudent.common;
using Microsoft.Extensions.DependencyInjection;

namespace LearnHub.Test
{
    public static class UnitTestServicesRegistration
    {
        public static void ConfigureApplicationServices(this IServiceCollection services)
        {

            #region Dep for Validation

            //IComment
            services.AddScoped<IValidator<IComment_Dto>, IComment_V>();
            services.AddScoped<IValidator<Create_Comment_Dto>, Create_Comment_V>();
            services.AddScoped<IValidator<Update_Comment_Dto>, Update_Comment_V>();


            //ICourse
            services.AddScoped<IValidator<ICourse_Dto>, ICourse_V>();
            services.AddScoped<IValidator<Create_Course_Dto>, Create_Course_V>();
            services.AddScoped<IValidator<Update_Course_Dto>, Update_Course_V>();


            //ISubCourse
            services.AddScoped<IValidator<ISubCourse_Dto>, ISubCourse_V>();
            services.AddScoped<IValidator<Create_SubCourse_Dto>, Create_SubCourse_V>();
            services.AddScoped<IValidator<Update_SubCourse_Dto>, Update_SubCourse_V>();


            //IPermistion
            services.AddScoped<IValidator<IPermistion_Dto>, IPermistion_V>();
            services.AddScoped<IValidator<Create_Permistion_Dto>, Create_Permistion_V>();
            services.AddScoped<IValidator<Update_Permistion_Dto>, Update_Permistion_V>();


            //IProfileStudent
            services.AddScoped<IValidator<Update_ProfileStudent_Dto>, Update_ProfileStudent_V>();


            //IProfileTeacher
            services.AddScoped<IValidator<Create_ProfileTeacher_Dto>, Create_ProfileTeacher_V>();
            services.AddScoped<IValidator<Update_ProfileTeacher_Dto>, Update_ProfileTeacher_V>();


            //BuyCourse
            services.AddScoped<IValidator<BuyCourse_Dto>, BuyCourse_V>();


            //ISupportAdmin
            services.AddScoped<IValidator<ISupportAdmin_Dto>, ISupportAdmin_V>();
            services.AddScoped<IValidator<Create_SupportAdmin_Dto>, Create_SupportAdmin_V>();
            services.AddScoped<IValidator<Update_SupportAdmin_Dto>, Update_SupportAdmin_V>();

            //ISupportStudent
            services.AddScoped<IValidator<ISupportStudent_Dto>, ISupportStudent_V>();
            services.AddScoped<IValidator<Create_SupportStudent_Dto>, Create_SupportStudent_V>();
            services.AddScoped<IValidator<Update_SupportStudent_Dto>, Update_SupportStudent_V>();

            #endregion




        }
    }
}
