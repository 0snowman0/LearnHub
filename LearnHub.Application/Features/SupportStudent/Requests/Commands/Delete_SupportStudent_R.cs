using LearnHub.Application.Responses;
using MediatR;

namespace LearnHub.Application.Features.SupportStudent.Requests.Commands
{
    public class Delete_SupportStudent_R : IRequest<BaseCommandResponse>
    {
        public  List<int> Ids { get; set; }
    }
}
