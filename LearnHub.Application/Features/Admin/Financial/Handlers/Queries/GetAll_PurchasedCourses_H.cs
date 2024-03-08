using AutoMapper;
using LearnHub.Application.Contracts.Course;
using LearnHub.Application.Contracts.FinancialSector;
using LearnHub.Application.Dto.Admin.Financial;
using LearnHub.Application.Features.Admin.Financial.Requests.Queries;
using LearnHub.Application.Responses;
using LearnHub.Domain.Model.course;
using MediatR;

namespace LearnHub.Application.Features.Admin.Financial.Handlers.Queries
{
    public class GetAll_PurchasedCourses_H : IRequestHandler<GetAll_PurchasedCourses_R, BaseCommandResponse>
    {
        private readonly ICoursePpurchased _coursePpurchased;
        private readonly IMapper _mapper;
        private readonly ICourse _course;
        public GetAll_PurchasedCourses_H
            (
            ICoursePpurchased coursePpurchased,
            IMapper mapper
,
            ICourse course)
        {
            _coursePpurchased = coursePpurchased;
            _mapper = mapper;
            _course = course;
        }

        public async Task<BaseCommandResponse> Handle(GetAll_PurchasedCourses_R request, CancellationToken cancellationToken)
        {
            var responce = new BaseCommandResponse();

            var PurchasedCourses = await _coursePpurchased.GetAll();

            if (!PurchasedCourses.Any())
            {
                responce.NotFound();
                return responce;
            }

            var PurchasedCourses_Dto = new TotalPurchasedCourses_Dto();
            var SubPurchasedCourses_Dtos = new List<SubPurchasedCourses_Dto>();


            foreach (var PC in PurchasedCourses)
            {
                var SubPurchasedCourses_Dto = new SubPurchasedCourses_Dto();
                var course = new Course_En();

                course = await _course.Get(PC.CourseId);

                SubPurchasedCourses_Dto.CourseName = course.CourseName;
                SubPurchasedCourses_Dto.Price = course.CoursePrice;

                SubPurchasedCourses_Dtos.Add(SubPurchasedCourses_Dto);
            }


            PurchasedCourses_Dto.course_Dtos = SubPurchasedCourses_Dtos;

            PurchasedCourses_Dto.TotalPrice = 0;
            PurchasedCourses_Dto.NumberCourse = 0;

            foreach (var item in SubPurchasedCourses_Dtos)
            {
                PurchasedCourses_Dto.TotalPrice += item.Price;
                PurchasedCourses_Dto.NumberCourse++;
            }

            responce.Success(PurchasedCourses_Dto);
            return responce;
        }
    }
}
