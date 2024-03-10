using AutoMapper;
using LearnHub.Application.Contracts.payment;
using LearnHub.Application.Contracts.Profile;
using LearnHub.Application.Dto.Financial.Payment.Queries;
using LearnHub.Application.Features.Profile.Student.Requests.Queries;
using LearnHub.Application.Responses;
using MediatR;

namespace LearnHub.Application.Features.Profile.Student.Handlers.Queries
{
    public class Get_ProfileStudent_H : IRequestHandler<Create_ProfileStudent_R, BaseCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly Ipayment _payment;
        private readonly IProfileStudent _profileStudent;
        public Get_ProfileStudent_H
            (
            IMapper mapper,
            Ipayment payment,
            IProfileStudent profileStudent
            )
        {
            _mapper = mapper;
            _payment = payment;
            _profileStudent = profileStudent;
        }

        public async Task<BaseCommandResponse> Handle(Create_ProfileStudent_R request, CancellationToken cancellationToken)
        {
            var responce = new BaseCommandResponse();


            // Get UserName & Email
            var ProfileStudent = await _profileStudent.GetProfileStudentWithUserId(request.UserId);

            if (ProfileStudent == null)
            {
                responce.NotFound();
                responce.Errors = new List<string> { $"not found user with id:{request.UserId}" };
                return responce;
            };

            var Payments = await _payment.GetPaymeentWithUserId(request.UserId);

            if(Payments.Any())
            {
                var PaymentDto = _mapper.Map<List<Get_Payment_Dto>>(Payments);
                ProfileStudent.get_Payment_Dtos = PaymentDto;
            }



            responce.Success(ProfileStudent);
            return responce;
        }

    }
}

