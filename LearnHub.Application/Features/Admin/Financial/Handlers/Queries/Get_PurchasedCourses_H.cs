using AutoMapper;
using LearnHub.Application.Contracts.Course;
using LearnHub.Application.Contracts.FinancialSector;
using LearnHub.Application.Dto.Admin.Financial;
using LearnHub.Application.Features.Admin.Financial.Requests.Queries;
using LearnHub.Application.Responses;
using MediatR;

namespace LearnHub.Application.Features.Admin.Financial.Handlers.Queries
{
    public class Get_PurchasedCourses_H : IRequestHandler<Get_PurchasedCourses_R, BaseCommandResponse>
    {
        private readonly ICoursePpurchased _coursePpurchased;
        private readonly IMapper _mapper;
        private readonly ICourse _course;
        public Get_PurchasedCourses_H(ICoursePpurchased coursePpurchased, IMapper mapper, ICourse course)
        {
            _coursePpurchased = coursePpurchased;
            _mapper = mapper;
            _course = course;
        }

        public async Task<BaseCommandResponse> Handle(Get_PurchasedCourses_R request, CancellationToken cancellationToken)
        {
            var responce = new BaseCommandResponse();


            var course = await _course.Get(request.CourseId);

            if (course == null) 
            {
                responce.NotFound();
                responce.Errors = new List<string> {$"not found course with id:{course.Id}" };
                return responce;
            }

            var PurchasCourse = await _coursePpurchased.GetWithCourseId(request.CourseId);

            if(PurchasCourse == null)
            {

                responce.NotFound();
                responce.Errors = new List<string> { $"not found PurchasCoursewith id:{PurchasCourse.Id}" };
                return responce;
            }

            var onePC = new OnePurchasedCourses_Dto()
            {
                CourseId = request.CourseId,
                CourseName = course.CourseName,
                TeacherName = request.TeacherName
            };


            responce.Success(onePC);
            return responce;
        }
    }
}
