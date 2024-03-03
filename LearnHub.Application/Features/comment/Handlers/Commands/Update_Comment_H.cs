using AutoMapper;
using LearnHub.Application.Contracts.comment;
using LearnHub.Application.Features.comment.Requests.Commands;
using LearnHub.Application.Responses;
using MediatR;

namespace LearnHub.Application.Features.comment.Handlers.Commands
{
    public class Update_Comment_H : IRequestHandler<Update_Comment_R, BaseCommandResponse>
    {
        private readonly IComment _comment;
        private readonly IMapper _mapper;

        public Update_Comment_H(IComment comment, IMapper mapper)
        {
            _comment = comment;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(Update_Comment_R request, CancellationToken cancellationToken)
        {
            var responce = new BaseCommandResponse();

            var Target = await _comment.Get(request.update_Comment_Dto.Id);

            if (Target == null) 
            {
                responce.NotFound();
                responce.Errors = new List<string> {$"not found commnet with id:{request.update_Comment_Dto.Id}." };
                return responce;
            }

            Target.Content = request.update_Comment_Dto.Content;

            Target.UpdatedAt = DateTime.Now;

            await _comment.SaveAsync();

            responce.Success();
            responce.StatusCode = 204;
            responce.Message = "Updated";
            return responce;
        }
    }
}
