using AutoMapper;
using LearnHub.Application.Contracts.Course;
using LearnHub.Application.Contracts.FinancialSector;
using LearnHub.Application.Dto.Course.course.Queries;
using LearnHub.Application.Features.Profile.Student.Requests.Queries;
using LearnHub.Application.Responses;
using LearnHub.Domain.Model.course;
using MediatR;

namespace LearnHub.Application.Features.Profile.Student.Handlers.Queries
{
    public class MyCourse_H : IRequestHandler<MyCourse_R, BaseCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICourse _course;
        private readonly ICoursePpurchased _coursePpurchased;
        public MyCourse_H
            (
            IMapper mapper,
            ICourse course,
            ICoursePpurchased coursePpurchased
            )
        {
            _mapper = mapper;
            _course = course;
            _coursePpurchased = coursePpurchased;
        }

        public async Task<BaseCommandResponse> Handle(MyCourse_R request, CancellationToken cancellationToken)
        {
            var responce = new BaseCommandResponse();

            var coursePpurchaseds = await _coursePpurchased.GetWithUserId(request.UserId);


            if(!coursePpurchaseds.Any())
            {
                responce.NotFound();
                return responce;    
            }

            var Courses = new List<Course_En>();

            foreach(var CP in coursePpurchaseds)
            {
                var course = await _course.Get(CP.CourseId);

                if(course != null) 
                    Courses.Add(course);
            }
            
            
            
            var CourseDto = _mapper.Map<List<Course_Dto>>(Courses);

            responce.Success(CourseDto);
            return responce;
        }
    }
}
