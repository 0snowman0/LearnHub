using LearnHub.Application.Responses;
using MediatR;

namespace LearnHub.Application.Features.Subcourse.Requests.Queries
{
    public class GetWithCourseId_SubCourse_R : IRequest<BaseCommandResponse>
    {
        public  int CourseId { get; set; }
    }
}
