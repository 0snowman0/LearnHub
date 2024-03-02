using AutoMapper;
using LearnHub.Application.Contracts.Support.SupportStudent;
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

        public Create_SupportStudent_H(IMapper mapper, ISupportStudent supportStudent)
        {
            _mapper = mapper;
            _supportStudent = supportStudent;
        }
        public async Task<BaseCommandResponse> Handle(Create_SupportStudent_R request, CancellationToken cancellationToken)
        {
            var responce = new BaseCommandResponse();


            //validation


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
