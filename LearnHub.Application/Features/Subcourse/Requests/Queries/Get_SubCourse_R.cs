using LearnHub.Application.Responses;
using MediatR;

namespace LearnHub.Application.Features.Subcourse.Requests.Queries
{
    public class Get_SubCourse_R : IRequest<BaseCommandResponse>
    {
        public  int Id { get; set; }
    }
}
