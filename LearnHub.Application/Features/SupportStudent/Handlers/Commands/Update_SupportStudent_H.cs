using AutoMapper;
using LearnHub.Application.Contracts.Support.SupportStudent;
using LearnHub.Application.Features.SupportStudent.Requests.Commands;
using LearnHub.Application.Responses;
using MediatR;

namespace LearnHub.Application.Features.SupportStudent.Handlers.Commands
{
    public class Update_SupportStudent_H : IRequestHandler<Update_SupportStudent_R, BaseCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISupportStudent _supportStudent;

        public Update_SupportStudent_H(IMapper mapper, ISupportStudent supportStudent)
        {
            _mapper = mapper;
            _supportStudent = supportStudent;
        }
        public async Task<BaseCommandResponse> Handle
            (Update_SupportStudent_R request, CancellationToken cancellationToken)
        {
            var responce = new BaseCommandResponse();


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
