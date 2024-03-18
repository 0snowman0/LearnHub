using AutoMapper;
using Dto.Payment;
using FluentValidation;
using LearnHub.Application.Contracts.Course;
using LearnHub.Application.Contracts.FinancialSector;
using LearnHub.Application.Contracts.payment;
using LearnHub.Application.Contracts.Tools;
using LearnHub.Application.Features.Store.Requests.Commands;
using LearnHub.Application.Responses;
using LearnHub.Domain.Model.FinancialSector;
using MediatR;
using ZarinPal.Class;
using static System.Net.Mime.MediaTypeNames;

namespace LearnHub.Application.Features.Store.Handlers.Commands
{
    public class FinallyBuyCourse_H : IRequestHandler<FinallyBuyCourse_R, BaseCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly Ipayment _Ipayment;
        private readonly ZarinPal.Class.Payment _payment;
        private readonly Authority _authority;
        private readonly Transactions _transactions;
        private readonly ICourse _course;
        private readonly IHelpFunction _helpFunction;
        private readonly ICoursePpurchased _coursePpurchased;

        public FinallyBuyCourse_H
            (IMapper mapper,
            Ipayment ipayment,
            ZarinPal.Class.Payment payment,
            Authority authority,
            Transactions transactions,
            ICourse course,
            IHelpFunction helpFunction,
            ICoursePpurchased coursePpurchased)
        {
            _mapper = mapper;
            _Ipayment = ipayment;
            _payment = payment;
            _authority = authority;
            _transactions = transactions;
            _course = course;
            _helpFunction = helpFunction;
            _coursePpurchased = coursePpurchased;
        }

        public async Task<BaseCommandResponse> Handle(FinallyBuyCourse_R request, CancellationToken cancellationToken)
        {
            var responce = new BaseCommandResponse();

            // Get the payment verification response
            var verification = await _payment.Verification(new DtoVerification
            {
                Authority = request.requesFromZarinpal.authority,
                MerchantId = "بعدا این فیلد توسط زرین پال پر خواهد شد "
            }, ZarinPal.Class.Payment.Mode.sandbox);


            if (verification.Status == 200)
            {
                // Update the payment status in the database
                var paymentTraget = await _Ipayment.GetPaymeentWithTrackingCode(request.requesFromZarinpal.TrackingCode);
                if (paymentTraget == null)
                {
                    responce.NotFound();
                    responce.Errors = new List<string> {$"not found" +
                        $"payment with TarckingCode:{request.requesFromZarinpal.TrackingCode}" };
                    return responce;
                }

                // The payment is successful
                paymentTraget.IsSucccess = true;


                var NewPurchesCourse = new CoursePpurchased_En()
                {
                    CourseId = paymentTraget.CourseId,
                    Student_Id = paymentTraget.UserId,
                    purchaseDate = DateTime.Now,
                };

                await _coursePpurchased.Add(NewPurchesCourse);




                responce.Success();
                responce.Message = $"Payment Target Add With Id:{paymentTraget.Id}...." +
                    $"And Add CoursePpurchased with Id:{NewPurchesCourse.Id}";
                return responce;
            }

            responce.Failure();
            responce.Errors = new List<string> {"ZarinPal Status != 200" };
            return responce;
        }
    }
}
