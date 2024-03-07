using LearnHub.Application.Responses;
using MediatR;

namespace LearnHub.Application.Features.Admin.course.Requests.Commands
{
    public class CourseApproval_R : IRequest<BaseCommandResponse>
    {
        public  List<int> CourseIds { get; set; }
    }
}
