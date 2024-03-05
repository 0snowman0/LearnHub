using AutoMapper;
using LearnHub.Application.Contracts.Course;
using LearnHub.Application.Dto.Course.subcourse.Queries;
using LearnHub.Application.Features.Subcourse.Requests.Queries;
using LearnHub.Application.Responses;
using LearnHub.Domain.Model.course;
using MediatR;

namespace LearnHub.Application.Features.Subcourse.Handlers.Queries
{
    public class Get_SubCourse_H : IRequestHandler<Get_SubCourse_R, BaseCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISubCourse _subCourse;

        public Get_SubCourse_H(IMapper mapper, ISubCourse subCourse)
        {
            _mapper = mapper;
            _subCourse = subCourse;
        }

        public async Task<BaseCommandResponse> Handle(Get_SubCourse_R request, CancellationToken cancellationToken)
        {
            var responce = new BaseCommandResponse();

            var SubCourse =await  _subCourse.GetAll();

            if(!SubCourse.Any())
            {
                responce.NotFound();
                return responce;
            }

            var SubCourseDto = _mapper.Map<List<SubCourse_Dto>>(SubCourse);

            responce.Success(SubCourseDto);
            return responce;
        }
    }
}
