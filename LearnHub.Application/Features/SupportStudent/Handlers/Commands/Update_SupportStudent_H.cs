using AutoMapper;
using FluentValidation;
using LearnHub.Application.Contracts.Support.SupportStudent;
using LearnHub.Application.Dto.Support.SupportStudent.command;
using LearnHub.Application.Features.SupportStudent.Requests.Commands;
using LearnHub.Application.Responses;
using MediatR;

namespace LearnHub.Application.Features.SupportStudent.Handlers.Commands
{
    public class Update_SupportStudent_H : IRequestHandler<Update_SupportStudent_R, BaseCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISupportStudent _supportStudent;
        private readonly IValidator<Update_SupportStudent_Dto> _validator;
        public Update_SupportStudent_H(IMapper mapper, ISupportStudent supportStudent, IValidator<Update_SupportStudent_Dto> validator)
        {
            _mapper = mapper;
            _supportStudent = supportStudent;
            _validator = validator;
        }
        public async Task<BaseCommandResponse> Handle
            (Update_SupportStudent_R request, CancellationToken cancellationToken)
        {
            var responce = new BaseCommandResponse();

            #region Validation
            var Validate = await _validator.ValidateAsync(request.update_SupportStudent_Dto);

            if (!Validate.IsValid)
            {
                responce.BadRequest(responce.ConvertValidationFailureToLisString(Validate.Errors));
                return responce;
            }
            #endregion

            var Target = await _supportStudent.Get(request.update_SupportStudent_Dto.Id);

            if(Target == null)
            {
                responce.Failure();
                responce.StatusCode = 404;
                responce.Errors = new List<string> 
                {$"not found supportStudent with id :{request.update_SupportStudent_Dto.Id}" };
                return responce;
            }

            Target = _mapper.Map(request.update_SupportStudent_Dto , Target);

            await _supportStudent.Update(Target);

            responce.Success();
            responce.StatusCode = 204;
            responce.Message = "success";
            return responce;
        }
    }
}
