using AutoMapper;
using AutoMapper.Configuration.Annotations;
using LearnHub.Application.Contracts.Support.SupportStudent;
using LearnHub.Application.Dto.Support.SupportStudent.Queries;
using LearnHub.Application.Features.SupportStudent.Requests.Queries;
using LearnHub.Application.Responses;
using MediatR;

namespace LearnHub.Application.Features.SupportStudent.Handlers.Queries
{
    public class Get_SupportStudent_H : IRequestHandler<Get_SupportStudent_R, BaseCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISupportStudent _supportStudent;

        public Get_SupportStudent_H(IMapper mapper, ISupportStudent supportStudent)
        {
            _mapper = mapper;
            _supportStudent = supportStudent;
        }
        public async Task<BaseCommandResponse> Handle(Get_SupportStudent_R request, CancellationToken cancellationToken)
        {
            var responce = new BaseCommandResponse();

            
            var supportStudent = await _supportStudent.Get(request.Id);

            if(supportStudent == null)
            {
                responce.Failure();
                responce.StatusCode = 404;
                responce.Errors = new List<string> { $"not founde support with id:{request.Id}" };
                return responce;
            }

            
            //map to dto
            var supportStudentDto = _mapper.Map<SupportStudent_Dto>(supportStudent);


            responce.Success(supportStudentDto);
            responce.StatusCode = 200;
            responce.Message = "success";
            return responce;
        }
    }
}
