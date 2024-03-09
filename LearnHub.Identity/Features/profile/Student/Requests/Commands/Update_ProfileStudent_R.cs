using LearnHub.Application.Dto.profile.Student.command;
using LearnHub.Application.Responses;
using MediatR;

namespace LearnHub.Identity.Features.profile.Student.Requests.Commands
{
    public class Update_ProfileStudent_R : IRequest<BaseCommandResponse>
    {
        public int UserId { get; set; } 
        public Update_ProfileStudent_Dto update_ProfileStudent { get; set; } = null!;
    }
}
