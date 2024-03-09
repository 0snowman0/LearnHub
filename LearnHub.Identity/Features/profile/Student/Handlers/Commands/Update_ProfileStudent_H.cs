using AutoMapper;
using LearnHub.Application.Contracts.Profile;
using LearnHub.Application.Responses;
using LearnHub.Identity.Features.profile.Student.Requests.Commands;
using LearnHub.Identity.IdentityService.Abstract;
using MediatR;

namespace LearnHub.Identity.Features.profile.Student.Handlers.Commands
{
    public class Update_ProfileStudent_H : IRequestHandler<Update_ProfileStudent_R, BaseCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly Iuser _user;

        public Update_ProfileStudent_H(IMapper mapper, Iuser user)
        {
            _mapper = mapper;
            _user = user;
        }

        public async Task<BaseCommandResponse> Handle(Update_ProfileStudent_R request, CancellationToken cancellationToken)
        {
            var responce = new BaseCommandResponse();

            var Target = await _user.Get(request.UserId);


            if (Target == null)
            {
                responce.NotFound();
                responce.Errors = new List<string> { $"not found user with id:{request.UserId};" };
                return responce;
            }

            _mapper.Map(request.update_ProfileStudent,Target);

            await _user.Update(Target);
            
            responce.Success();
            responce.StatusCode = 204;
            return responce;
        }
    }
}
