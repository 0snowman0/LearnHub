using AutoMapper;
using FluentValidation;
using LearnHub.Application.Contracts.Profile;
using LearnHub.Application.Dto.profile.Teacher.command;
using LearnHub.Application.Features.Profile.Teacher.Requests.Commands;
using LearnHub.Application.Responses;
using LearnHub.Application.Validation.profile.Teacher.command;
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
        private readonly IValidator<Create_ProfileTeacher_Dto> _validator;

        public Create_ProfileTeacher_H(IMapper mapper, IProfileTeacher profileTeacher, IFileService fileService, IValidator<Create_ProfileTeacher_Dto> validator)
        {
            _mapper = mapper;
            _profileTeacher = profileTeacher;
            _fileService = fileService;
            _validator = validator;
        }

        public async Task<BaseCommandResponse> Handle(Create_ProfileTeacher_R request, CancellationToken cancellationToken)
        {
            var responce = new BaseCommandResponse();



            #region Validation
            var Validate = await _validator.ValidateAsync(request.create_ProfileTeacher_Dto);

            if (!Validate.IsValid)
            {
                responce.BadRequest(responce.ConvertValidationFailureToLisString(Validate.Errors));
                return responce;
            }
            #endregion


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
