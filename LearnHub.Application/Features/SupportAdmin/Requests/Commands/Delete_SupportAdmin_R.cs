using LearnHub.Application.Responses;
using MediatR;

namespace LearnHub.Application.Features.SupportAdmin.Requests.Commands
{
    public class Delete_SupportAdmin_R : IRequest<BaseCommandResponse>
    {
        public  List<int> Ids { get; set; }
    }
}
