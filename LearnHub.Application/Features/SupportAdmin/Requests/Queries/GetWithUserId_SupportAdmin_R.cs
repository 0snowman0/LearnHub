using LearnHub.Application.Responses;
using MediatR;

namespace LearnHub.Application.Features.SupportAdmin.Requests.Queries
{
    public class GetWithUserId_SupportAdmin_R : IRequest<BaseCommandResponse>
    {
        public  int AdminId { get; set; }
    }
}
