using AutoMapper;
using LearnHub.Application.Contracts.Profile;
using LearnHub.Application.Features.Profile.Teacher.Requests.Commands;
using LearnHub.Application.Responses;
using MediatR;

namespace LearnHub.Application.Features.Profile.Teacher.Handlers.Commands
{
    public class Update_ProfileTeacher_H 
        : IRequestHandler<Update_ProfileTeacher_R, BaseCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProfileTeacher _profileTeacher;

        public Update_ProfileTeacher_H
            (
            IMapper mapper,
            IProfileTeacher profileTeacher
            )
        {
            _mapper = mapper;
            _profileTeacher = profileTeacher;
        }

        public async Task<BaseCommandResponse> Handle(Update_ProfileTeacher_R request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            var Target = await _profileTeacher.GetWithUserId(request.UserId);

            if( Target == null )
            {
                response.NotFound();
                return response;
            }

            _mapper.Map(request.update_ProfileTeacher, Target);

            await _profileTeacher.Update(Target);

            response.Success();
            response.StatusCode = 204;
            return response;
        }
    }
}
