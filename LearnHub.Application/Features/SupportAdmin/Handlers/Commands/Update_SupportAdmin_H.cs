using AutoMapper;
using FluentValidation;
using LearnHub.Application.Contracts.Support.SupportAdmin;
using LearnHub.Application.Dto.Support.SupportAdmin.command;
using LearnHub.Application.Features.SupportAdmin.Requests.Commands;
using LearnHub.Application.Responses;
using LearnHub.Application.Validation.Support.SupportAdmin.command;
using MediatR;

namespace LearnHub.Application.Features.SupportAdmin.Handlers.Commands
{
    public class Update_SupportAdmin_H : IRequestHandler<Update_SupportAdmin_R, BaseCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISupportAdmin _supportAdmin;
        private readonly IValidator<Update_SupportAdmin_Dto> _validator;

        public Update_SupportAdmin_H(IMapper mapper, ISupportAdmin supportAdmin, IValidator<Update_SupportAdmin_Dto> validator)
        {
            _mapper = mapper;
            _supportAdmin = supportAdmin;
            _validator = validator;
        }

        public async Task<BaseCommandResponse> Handle(Update_SupportAdmin_R request, CancellationToken cancellationToken)
        {
            var responce = new BaseCommandResponse();


            #region Validation
            var Validate = await _validator.ValidateAsync(request.update_SupportAdmin_Dto);

            if (!Validate.IsValid)
            {
                responce.BadRequest(responce.ConvertValidationFailureToLisString(Validate.Errors));
                return responce;
            }
            #endregion


            var Target = await _supportAdmin.Get(request.update_SupportAdmin_Dto.Id);

            if (Target == null)
            {
                responce.NotFound();
                responce.Errors = new List<string> {$"not found supportAdmin With Id:" +
                    $"{request.update_SupportAdmin_Dto.Id}" };
                return responce;
            }

            _mapper.Map(request.update_SupportAdmin_Dto, Target);

            Target.UpdateAnswer = DateTime.Now;

            await _supportAdmin.Update(Target);

            responce.Success();
            responce.Message = "updated";
            responce.StatusCode = 204;
            return responce;
        }
    }
}
