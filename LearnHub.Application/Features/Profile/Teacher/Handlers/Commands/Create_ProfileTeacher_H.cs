using AutoMapper;
using LearnHub.Application.Contracts.Profile;
using LearnHub.Application.Features.Profile.Teacher.Requests.Commands;
using LearnHub.Application.Responses;
using LearnHub.Domain.Model.Prifile.Teacher;
using LearnHub.File.Interface;
using MediatR;

namespace LearnHub.Application.Features.Profile.Teacher.Handlers.Commands
{
    public class Create_ProfileTeacher_H : IRequestHandler<Create_ProfileTeacher_R, BaseCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProfileTeacher _profileTeacher;
        private readonly IFileService _fileService;
        public Create_ProfileTeacher_H(IMapper mapper, IProfileTeacher profileTeacher, IFileService fileService)
        {
            _mapper = mapper;
            _profileTeacher = profileTeacher;
            _fileService = fileService;
        }

        public async Task<BaseCommandResponse> Handle(Create_ProfileTeacher_R request, CancellationToken cancellationToken)
        {
            var responce = new BaseCommandResponse();

            var NewProfileTeacher = _mapper.Map<TeacherProfile_En>(request.create_ProfileTeacher_Dto);
            NewProfileTeacher.UserId = request.UserId;


            var imageResult = _fileService.ReturnImageName(request.create_ProfileTeacher_Dto.ImageFile);

            if (imageResult.Item1 == 1)
                NewProfileTeacher.ImageName = imageResult.Item2;

           
            await _profileTeacher.Add(NewProfileTeacher);

            responce.Success($"Id:{NewProfileTeacher.Id}");
            return responce;
        }
    }
}
