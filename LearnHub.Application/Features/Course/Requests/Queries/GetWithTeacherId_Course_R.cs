using LearnHub.Application.Responses;
using MediatR;

namespace LearnHub.Application.Features.Course.Requests.Queries
{
    public class GetWithTeacherId_Course_R : IRequest<BaseCommandResponse>
    {
        public  int TeacherId { get; set; }
    }
}
