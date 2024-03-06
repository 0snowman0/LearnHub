using LearnHub.Application.Dto.store.command;
using LearnHub.Application.Responses;
using MediatR;

namespace LearnHub.Application.Features.Store.Requests.Commands
{
    public class FinallyBuyCourse_R : IRequest<BaseCommandResponse>
    {
        public RequesFromZarinpal_Dto requesFromZarinpal { get; set; } = null!;
    }
}
