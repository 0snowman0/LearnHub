using AutoMapper;
using LearnHub.Application.Contracts.Support.SupportStudent;
using LearnHub.Application.Features.SupportStudent.Requests.Commands;
using LearnHub.Application.Responses;
using MediatR;

namespace LearnHub.Application.Features.SupportStudent.Handlers.Commands
{
    public class Delete_SupportStudent_H : IRequestHandler<Delete_SupportStudent_R, BaseCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISupportStudent _supportStudent;

        public Delete_SupportStudent_H(IMapper mapper, ISupportStudent supportStudent)
        {
            _mapper = mapper;
            _supportStudent = supportStudent;
        }
        public async Task<BaseCommandResponse> Handle(Delete_SupportStudent_R request, CancellationToken cancellationToken)
        {
            var responce = new BaseCommandResponse();


            await _supportStudent.Delete(request.Ids);

            responce.Success();
            responce.Message = "delete is success";
            responce.StatusCode = 204;
            return responce;
        }
    }
}
