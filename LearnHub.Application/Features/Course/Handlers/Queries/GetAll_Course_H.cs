using AutoMapper;
using LearnHub.Application.Contracts.Course;
using LearnHub.Application.Dto.Course.course.Queries;
using LearnHub.Application.Features.Course.Requests.Queries;
using LearnHub.Application.Responses;
using MediatR;

namespace LearnHub.Application.Features.Course.Handlers.Queries
{
    public class GetAll_Course_H : IRequestHandler<GetAll_Course_R, BaseCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICourse _course;

        public GetAll_Course_H(IMapper mapper, ICourse course)
        {
            _mapper = mapper;
            _course = course;
        }

        public async Task<BaseCommandResponse> Handle(GetAll_Course_R request, CancellationToken cancellationToken)
        {
            var responce = new BaseCommandResponse();

            var course = await _course.GetAll();

            if (!course.Any())
            {
                responce.NotFound();
                return responce;
            }

            var CourseDto = _mapper.Map<List<Course_Dto>>(course);


            responce.Success(CourseDto);
            responce.StatusCode = 200;
            return responce;
        }
    }
}
