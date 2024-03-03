using AutoMapper;
using LearnHub.Application.Contracts.comment;
using LearnHub.Application.Features.comment.Requests.Commands;
using LearnHub.Application.Responses;
using LearnHub.Domain.Model.Comment;
using MediatR;

namespace LearnHub.Application.Features.comment.Handlers.Commands
{
    public class Create_Comment_H : IRequestHandler<Create_Comment_R, BaseCommandResponse>
    {
        private readonly IComment _comment;
        private readonly IMapper _mapper;

        public Create_Comment_H(IComment comment, IMapper mapper)
        {
            _comment = comment;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(Create_Comment_R request, CancellationToken cancellationToken)
        {
            var responce = new BaseCommandResponse();

            var NewComment = _mapper.Map<Comment_En>(request.create_Comment_Dto);
            NewComment.CreatedAt = DateTime.Now;
            NewComment.UpdatedAt = DateTime.Now;
            NewComment.UserId = request.UserId;

            await _comment.Add(NewComment);

            
            responce.Success(NewComment.Id);
            responce.StatusCode = 200;
            responce.Message = "Comment created successfully";
            return responce;
        }
    }
}
