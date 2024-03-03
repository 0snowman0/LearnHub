using LearnHub.Application.Responses;
using MediatR;

namespace LearnHub.Application.Features.comment.Requests.Queries
{
    public class GetWithCourseId_Comment_R : IRequest<BaseCommandResponse>
    {
        public  int CourseId { get; set; }
    }
}
