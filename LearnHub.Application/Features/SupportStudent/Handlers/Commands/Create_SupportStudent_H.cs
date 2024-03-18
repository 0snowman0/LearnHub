using AutoMapper;
using FluentValidation;
using LearnHub.Application.Contracts.Support.SupportStudent;
using LearnHub.Application.Dto.Support.SupportStudent.command;
using LearnHub.Application.Features.SupportStudent.Requests.Commands;
using LearnHub.Application.Responses;
using LearnHub.Domain.Model.Support;
using MediatR;

namespace LearnHub.Application.Features.SupportStudent.Handlers.Commands
{
    public class Create_SupportStudent_H : IRequestHandler<Create_SupportStudent_R, BaseCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISupportStudent _supportStudent;
        private readonly IValidator<Create_SupportStudent_Dto> _validator;
        public Create_SupportStudent_H
            (IMapper mapper, 
            ISupportStudent supportStudent, 
            IValidator<Create_SupportStudent_Dto> validator)
        {
            _mapper = mapper;
            _supportStudent = supportStudent;
            _validator = validator;
        }
        public async Task<BaseCommandResponse> Handle(Create_SupportStudent_R request, CancellationToken cancellationToken)
        {
            var responce = new BaseCommandResponse();


            #region Validation
            var Validate = await _validator.ValidateAsync(request.create_SupportStudent_Dto);

            if (!Validate.IsValid)
            {
                responce.BadRequest(responce.ConvertValidationFailureToLisString(Validate.Errors));
                return responce;
            }
            #endregion

            var NewSupportStudent = _mapper.Map<SupportStudent_En>(request.create_SupportStudent_Dto);
            NewSupportStudent.UserId = request.UserId;
            NewSupportStudent.Date = DateTime.UtcNow;

            await _supportStudent.Add(NewSupportStudent);

            responce.Success(NewSupportStudent.Id);
            responce.StatusCode = 200;
            responce.Message = "success";
            return responce;
        }
    }
}
