using AutoMapper;
using FluentValidation;
using LearnHub.Application.Contracts.Support.SupportAdmin;
using LearnHub.Application.Dto.Support.SupportAdmin.command;
using LearnHub.Application.Features.SupportAdmin.Requests.Commands;
using LearnHub.Application.Responses;
using LearnHub.Application.Validation.Support.SupportAdmin.command;
using LearnHub.Domain.Model.Support;
using MediatR;

namespace LearnHub.Application.Features.SupportAdmin.Handlers.Commands
{
    public class Create_SupportAdmin_H : IRequestHandler<Create_SupportAdmin_R, BaseCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISupportAdmin _supportAdmin;
        private readonly IValidator<Create_SupportAdmin_Dto> _validator;
        public Create_SupportAdmin_H(IMapper mapper, ISupportAdmin supportAdmin, IValidator<Create_SupportAdmin_Dto> validator)
        {
            _mapper = mapper;
            _supportAdmin = supportAdmin;
            _validator = validator;
        }

        public async Task<BaseCommandResponse> Handle(Create_SupportAdmin_R request, CancellationToken cancellationToken)
        {
            var responce = new BaseCommandResponse();


            #region Validation
            var Validate = await _validator.ValidateAsync(request.create_SupportAdmin_Dto);

            if (!Validate.IsValid)
            {
                responce.BadRequest(responce.ConvertValidationFailureToLisString(Validate.Errors));
                return responce;
            }
            #endregion


            var NewSupportAdmin = _mapper.Map<SupportAdmin_En>(request.create_SupportAdmin_Dto);

            NewSupportAdmin.AdminId = request.AdminId;
            NewSupportAdmin.AnswerDate = DateTime.Now;
            NewSupportAdmin.UpdateAnswer = DateTime.Now;

            await _supportAdmin.Add(NewSupportAdmin);

            responce.Success(NewSupportAdmin.Id);
            responce.StatusCode = 200;
            responce.Message = "Created";
            return responce;
        }
    }
}
