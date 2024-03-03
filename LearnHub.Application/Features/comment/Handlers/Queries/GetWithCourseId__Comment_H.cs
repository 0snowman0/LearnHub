using AutoMapper;
using LearnHub.Application.Contracts.comment;
using LearnHub.Application.Dto.comment.Queries;
using LearnHub.Application.Features.comment.Requests.Queries;
using LearnHub.Application.Responses;
using MediatR;

namespace LearnHub.Application.Features.comment.Handlers.Queries
{
    public class GetWithCourseId_Comment_H : IRequestHandler<GetWithCourseId_Comment_R, BaseCommandResponse>
    {
        private readonly IComment _comment;
        private readonly IMapper _mapper;

        public GetWithCourseId_Comment_H(IComment comment, IMapper mapper)
        {
            _comment = comment;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(GetWithCourseId_Comment_R request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            var Comments = await _comment.GetWithCourseId(request.CourseId);

            if (!Comments.Any())
            {
                response.NotFound();
                return response;
            }

            var CommentsDto = _mapper.Map<List<Comment_Dto>>(Comments);

            response.Success(CommentsDto);
            response.StatusCode = 200;
            response.Message = "Success";
            return response;
        }
    }
}
