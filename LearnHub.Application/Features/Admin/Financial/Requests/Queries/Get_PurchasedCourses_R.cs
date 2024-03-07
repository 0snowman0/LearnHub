using LearnHub.Application.Responses;
using MediatR;

namespace LearnHub.Application.Features.Admin.Financial.Requests.Queries
{
    public class Get_PurchasedCourses_R : IRequest<BaseCommandResponse>
    {
        public int CourseId { get; set; }
        public string TeacherName { get; set; } = null!;
    }
}
