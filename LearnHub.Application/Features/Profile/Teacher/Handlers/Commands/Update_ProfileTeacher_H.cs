using AutoMapper;
using FluentValidation;
using LearnHub.Application.Contracts.Profile;
using LearnHub.Application.Dto.profile.Teacher.command;
using LearnHub.Application.Features.Profile.Teacher.Requests.Commands;
using LearnHub.Application.Responses;
using LearnHub.Application.Validation.profile.Teacher.command;
using MediatR;

namespace LearnHub.Application.Features.Profile.Teacher.Handlers.Commands
{
    public class Update_ProfileTeacher_H 
        : IRequestHandler<Update_ProfileTeacher_R, BaseCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProfileTeacher _profileTeacher;
        private readonly IValidator<Update_ProfileTeacher_Dto> _validator;

        public Update_ProfileTeacher_H
            (
            IMapper mapper,
            IProfileTeacher profileTeacher
,
            IValidator<Update_ProfileTeacher_Dto> validator)
        {
            _mapper = mapper;
            _profileTeacher = profileTeacher;
            _validator = validator;
        }

        public async Task<BaseCommandResponse> Handle(Update_ProfileTeacher_R request, CancellationToken cancellationToken)
        {
            var responce = new BaseCommandResponse();


            #region Validation
            var Validate = await _validator.ValidateAsync(request.update_ProfileTeacher);

            if (!Validate.IsValid)
            {
                responce.BadRequest(responce.ConvertValidationFailureToLisString(Validate.Errors));
                return responce;
            }
            #endregion


            var Target = await _profileTeacher.GetWithUserId(request.UserId);

            if( Target == null )
            {
                responce.NotFound();
                return responce;
            }

            _mapper.Map(request.update_ProfileTeacher, Target);

            await _profileTeacher.Update(Target);

            responce.Success();
            responce.StatusCode = 204;
            return responce;
        }
    }
}
