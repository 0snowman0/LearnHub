using LearnHub.Application.Responses;
using MediatR;

namespace LearnHub.Application.Features.SupportAdmin.Requests.Queries
{
    public class Get_SupportAdmin_R : IRequest<BaseCommandResponse>
    {
        public  int Id { get; set; }
    }
}
