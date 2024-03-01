using LearnHub.Application.Responses;
using MediatR;

namespace LearnHub.Application.Features.Payment.Requests.Queries
{
    public class Get_Payment_R : IRequest<BaseCommandResponse>
    {
        public  int Id { get; set; }
    }
}
