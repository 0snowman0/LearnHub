using AutoMapper;
using LearnHub.Application.Contracts.Support.SupportStudent;
using LearnHub.Application.Dto.Support.SupportStudent.Queries;
using LearnHub.Application.Features.SupportStudent.Requests.Queries;
using LearnHub.Application.Responses;
using MediatR;

namespace LearnHub.Application.Features.SupportStudent.Handlers.Queries
{
    public class GetAll_SupportStudent_H : IRequestHandler<GetAll_SupportStudent_R, BaseCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISupportStudent _supportStudent;

        public GetAll_SupportStudent_H(IMapper mapper, ISupportStudent supportStudent)
        {
            _mapper = mapper;
            _supportStudent = supportStudent;
        }
        public async Task<BaseCommandResponse> Handle(GetAll_SupportStudent_R request, CancellationToken cancellationToken)
        {
            var responce = new BaseCommandResponse();


            var supportStudentAll = await _supportStudent.GetAll();

            if(!supportStudentAll.Any())
            {
                responce.Failure();
                responce.StatusCode = 404;
                responce.Errors = new List<string> {"not found any support" };
                return responce;
            }


            //map
            var supportStudentDTOs = _mapper.Map<List<SupportStudent_Dto>>(supportStudentAll);

            responce.Success(supportStudentDTOs);
            responce.StatusCode = 200;
            responce.Message = "success";
            return responce;
        }
    }
}
