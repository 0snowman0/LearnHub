using AutoMapper;
using LearnHub.Application.Contracts.FinancialSector;
using LearnHub.Application.Dto.Admin.Financial;
using LearnHub.Application.Features.Admin.Financial.Requests.Queries;
using LearnHub.Application.Responses;
using MediatR;

namespace LearnHub.Application.Features.Admin.Financial.Handlers.Queries
{
    public class GetAll_PurchasedCourses_H : IRequestHandler<GetAll_PurchasedCourses_R, BaseCommandResponse>
    {
        private readonly ICoursePpurchased _coursePpurchased;
        private readonly IMapper _mapper;

        public GetAll_PurchasedCourses_H
            (
            ICoursePpurchased coursePpurchased,
            IMapper mapper
            )
        {
            _coursePpurchased = coursePpurchased;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(GetAll_PurchasedCourses_R request, CancellationToken cancellationToken)
        {
            var responce = new BaseCommandResponse();

            var PurchasedCourses = await _coursePpurchased.GetAll();

            if(!PurchasedCourses.Any())
            {
                responce.NotFound();
                return responce;
            }

            var PurchasedCourses_Dto = new TotalPurchasedCourses_Dto();
            var SubPurchasedCourses_Dto = new List<SubPurchasedCourses_Dto>();


            SubPurchasedCourses_Dto = _mapper.Map<List<SubPurchasedCourses_Dto>>(PurchasedCourses);

            PurchasedCourses_Dto.course_Dtos = SubPurchasedCourses_Dto;

            PurchasedCourses_Dto.TotalPrice = 0;
            PurchasedCourses_Dto.NumberCourse = 0;

            foreach(var item in SubPurchasedCourses_Dto)
            {
                PurchasedCourses_Dto.TotalPrice += item.Price;
                PurchasedCourses_Dto.NumberCourse ++;
            }

            responce.Success(PurchasedCourses_Dto);
            return responce;    
        }
    }
}
