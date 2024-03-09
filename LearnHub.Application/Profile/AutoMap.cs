using LearnHub.Application.Dto.comment.command;
using LearnHub.Application.Dto.comment.Queries;
using LearnHub.Application.Dto.Course.course.command;
using LearnHub.Application.Dto.Course.course.Queries;
using LearnHub.Application.Dto.Course.subcourse.command;
using LearnHub.Application.Dto.Course.subcourse.Queries;
using LearnHub.Application.Dto.Financial.Payment.Queries;
using LearnHub.Application.Dto.profile.Student.command;
using LearnHub.Application.Dto.Support.SupportAdmin.command;
using LearnHub.Application.Dto.Support.SupportAdmin.Queries;
using LearnHub.Application.Dto.Support.SupportStudent.command;
using LearnHub.Application.Dto.Support.SupportStudent.Queries;
using LearnHub.Domain.Model.Comment;
using LearnHub.Domain.Model.course;
using LearnHub.Domain.Model.FinancialSector;
using LearnHub.Domain.Model.Support;

namespace LearnHub.Application.Profile
{
    public class AutoMap : AutoMapper.Profile
    {
        public AutoMap()
        {
            #region supportStudent

            CreateMap<Create_SupportStudent_Dto, SupportStudent_En>()
          .ForMember(dest => dest.Question, opt => opt.MapFrom(src => src.Question)).ReverseMap();


            CreateMap<SupportStudent_En , Update_SupportStudent_Dto>().ReverseMap();
            
            CreateMap<SupportStudent_En , SupportStudent_Dto>().ReverseMap();

            #endregion


            #region support Admin

            CreateMap<SupportAdmin_En, SupportAdmin_Dto>().ReverseMap();

            CreateMap<SupportAdmin_En, Create_SupportAdmin_Dto>()
                .ForMember(dest => dest.SupportStudentId , opt => opt.MapFrom(src => src.SupportStudentId))
                .ForMember(dest => dest.Answer, opt => opt.MapFrom(src => src.Answer)).ReverseMap();

            CreateMap<SupportAdmin_En, Update_SupportAdmin_Dto>().ReverseMap();

            #endregion


            #region Comment

            CreateMap<Comment_En,Comment_Dto>().ReverseMap();

            CreateMap<Comment_En,Create_Comment_Dto>().ReverseMap();
            
            CreateMap<Comment_En,Update_Comment_Dto>().ReverseMap();
            #endregion


            #region Course

            CreateMap<Course_En, Course_Dto>().ReverseMap();

            CreateMap<Course_En, Create_Course_Dto>().ReverseMap();
            
            CreateMap<Course_En, Update_Course_Dto>().ReverseMap();

            #endregion


            #region SubCourse

            CreateMap<SubCourse_En , SubCourse_Dto>().ReverseMap();

            CreateMap<SubCourse_En , Create_SubCourse_Dto>().ReverseMap();

            CreateMap<SubCourse_En , Update_SubCourse_Dto>().ReverseMap();

            CreateMap<SubCourse_En , UpdateVedio_SubCourse_Dto>().ReverseMap();
            #endregion

            
            #region Payment 

            CreateMap<Payment_En,Get_Payment_Dto>().ReverseMap();

            #endregion
        }
    }
}
