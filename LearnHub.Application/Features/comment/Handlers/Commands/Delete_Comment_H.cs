using AutoMapper;
using LearnHub.Application.Contracts.comment;
using LearnHub.Application.Features.comment.Requests.Commands;
using LearnHub.Application.Responses;
using MediatR;

namespace LearnHub.Application.Features.comment.Handlers.Commands
{
    public class Delete_Comment_H : IRequestHandler<Delete_Comment_R, BaseCommandResponse>
    {
        private readonly IComment _comment;
        private readonly IMapper _mapper;

        public Delete_Comment_H(IComment comment, IMapper mapper)
        {
            _comment = comment;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(Delete_Comment_R request, CancellationToken cancellationToken)
        {
            var responce = new BaseCommandResponse();

            await _comment.Delete(request.Ids);

            responce.Success();
            responce.StatusCode = 204;
            responce.Message = "Comment Deleted Successfully";
            return responce;
        }
    }
}
