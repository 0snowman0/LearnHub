using LearnHub.Application.Dto.store.command;
using LearnHub.Application.Responses;
using MediatR;

namespace LearnHub.Application.Features.Store.Requests.Queries
{
    public class BuyCourse_R : IRequest<BaseCommandResponse>
    {
        public int CourseId { get; set; }
        public  int UserId { get; set; }
    }
}