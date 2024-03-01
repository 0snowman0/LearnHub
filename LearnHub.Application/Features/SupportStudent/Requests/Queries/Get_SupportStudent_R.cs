using LearnHub.Application.Responses;
using MediatR;

namespace LearnHub.Application.Features.SupportStudent.Requests.Queries
{
    public class Get_SupportStudent_R : IRequest<BaseCommandResponse>
    {
        public  int Id { get; set; }
    }
}
