using AutoMapper;
using Dto.Payment;
using LearnHub.Application.Contracts.Course;
using LearnHub.Application.Contracts.payment;
using LearnHub.Application.Contracts.Tools;
using LearnHub.Application.Features.Store.Requests.Queries;
using LearnHub.Application.Responses;
using LearnHub.Domain.Model.FinancialSector;
using MediatR;
using System.Net.NetworkInformation;
using ZarinPal.Class;

namespace LearnHub.Application.Features.Store.Handlers.Queries
{
    public class BuyCourse_H : IRequestHandler<BuyCourse_R, BaseCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly Ipayment _Ipayment;
        private readonly ZarinPal.Class.Payment _payment;
        private readonly Authority _authority;
        private readonly Transactions _transactions;
        private readonly ICourse _course;
        private readonly IHelpFunction _helpFunction;
        public BuyCourse_H
            (IMapper mapper,
            Ipayment ipayment,
            ZarinPal.Class.Payment payment,
            Authority authority,
            Transactions transactions,
            ICourse course,
            IHelpFunction helpFunction)
        {
            _mapper = mapper;
            _Ipayment = ipayment;
            _payment = payment;
            _authority = authority;
            _transactions = transactions;
            _course = course;
            _helpFunction = helpFunction;
        }

        public async Task<BaseCommandResponse> Handle(BuyCourse_R request, CancellationToken cancellationToken)
        {
            var responce = new BaseCommandResponse();

            var Course = await _course.Get(request.CourseId);

            if (Course == null) 
            {
                responce.NotFound();
                return responce;
            }

            var NewPayment = new Payment_En()
            {
                Amount = Course.CoursePrice,
                CourseId = request.CourseId,
                Date = DateTime.UtcNow,
                IsSucccess = false,
                TrackingCode = _helpFunction.GenerateRandomString(10),
                UserId = request.UserId 
            };



            //zarinpal ...
            var requests = await _payment.Request(new DtoRequest
            {
                Amount = Course.CoursePrice,
                CallbackUrl = "https://localhost:44368/api/ZarinPal/verifyFood",
                Description = "nothing ...",
                Email = "kasramasra911@gmail.com",
                Mobile = "09011901198",
                MerchantId = "بعدا این فیلد توسط زرین پال پر خواهد شد "

            }, ZarinPal.Class.Payment.Mode.sandbox);


            await _Ipayment.Add(NewPayment);

            responce.Success(NewPayment);
            responce.Message = "your purchase will be registered after zarinPal approval";
            return responce;
        }
    }
}
