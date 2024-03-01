using LearnHub.Application.Responses;
using MediatR;

namespace LearnHub.Application.Features.SupportStudent.Requests.Queries
{
    public class GetWithUserId_SupportStudent_R : IRequest<BaseCommandResponse>
    {
        public  int UserId { get; set; }
    }
}
