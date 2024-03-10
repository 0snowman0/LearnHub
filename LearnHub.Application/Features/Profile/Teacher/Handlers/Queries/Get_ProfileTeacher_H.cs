using AutoMapper;
using LearnHub.Application.Contracts.Profile;
using LearnHub.Application.Dto.profile.Teacher.Queries;
using LearnHub.Application.Features.Profile.Teacher.Requests.Queries;
using LearnHub.Application.Responses;
using MediatR;

namespace LearnHub.Application.Features.Profile.Teacher.Handlers.Queries
{
    public class Get_ProfileTeacher_H : IRequestHandler<Get_ProfileTeacher_R, BaseCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProfileTeacher _profileTeacher;

        public Get_ProfileTeacher_H(IMapper mapper, IProfileTeacher profileTeacher)
        {
            _mapper = mapper;
            _profileTeacher = profileTeacher;
        }

        public async Task<BaseCommandResponse> Handle(Get_ProfileTeacher_R request, CancellationToken cancellationToken)
        {
            var responce = new BaseCommandResponse();

            var ProfileTeacher = await _profileTeacher.GetWithUserId(request.UserId);

            if (ProfileTeacher == null)
            {
                responce.NotFound();
                responce.Errors = new List<string> { $"not found profile teacher with user id :{request.UserId};" };
                return responce;
            }

            var MapDto = _mapper.Map<Get_ProfileTeacher_Dto>(ProfileTeacher);
            MapDto.TeacherName = request.UserName;

            responce.Success(MapDto);
            return responce;
        }
    }
}
