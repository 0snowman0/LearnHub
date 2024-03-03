using LearnHub.Application.Dto.comment.command;
using LearnHub.Application.Dto.comment.Queries;
using LearnHub.Application.Dto.Support.SupportAdmin.command;
using LearnHub.Application.Dto.Support.SupportAdmin.Queries;
using LearnHub.Application.Dto.Support.SupportStudent.command;
using LearnHub.Application.Dto.Support.SupportStudent.Queries;
using LearnHub.Domain.Model.Comment;
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
        }
    }
}
