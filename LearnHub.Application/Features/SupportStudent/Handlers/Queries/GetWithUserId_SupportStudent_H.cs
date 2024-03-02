using AutoMapper;
using LearnHub.Application.Contracts.Support.SupportStudent;
using LearnHub.Application.Dto.Support.SupportStudent.Queries;
using LearnHub.Application.Features.SupportStudent.Requests.Queries;
using LearnHub.Application.Responses;
using MediatR;

namespace LearnHub.Application.Features.SupportStudent.Handlers.Queries
{
    public class GetWithUserId_SupportStudent_H
        : IRequestHandler<GetWithUserId_SupportStudent_R, BaseCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISupportStudent _supportStudent;

        public GetWithUserId_SupportStudent_H(IMapper mapper, ISupportStudent supportStudent)
        {
            _mapper = mapper;
            _supportStudent = supportStudent;
        }

        public async Task<BaseCommandResponse> Handle(GetWithUserId_SupportStudent_R request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            //validation


            //logic
            var supportStudent = await _supportStudent.GetSupportStudentWithUserId(request.UserId);

            if (!supportStudent.Any())
            {
                response.Failure();
                response.StatusCode = 404;
                response.Errors = new List<string> { "support not found" };
                return response;
            }

            var result = _mapper.Map<List<SupportStudent_Dto>>(supportStudent);


            response.Success(result);
            response.StatusCode = 200;
            response.Message = "success";

            return response;
        }
    }
}
