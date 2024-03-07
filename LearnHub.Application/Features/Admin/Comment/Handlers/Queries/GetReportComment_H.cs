using AutoMapper;
using LearnHub.Application.Contracts.comment;
using LearnHub.Application.Dto.comment.Queries;
using LearnHub.Application.Features.Admin.Comment.Requests.Queries;
using LearnHub.Application.Responses;
using MediatR;

namespace LearnHub.Application.Features.Admin.Comment.Handlers.Queries
{
    public class GetReportComment_H : IRequestHandler<GetReportComment_R, BaseCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IComment _comment;

        public GetReportComment_H(IMapper mapper, IComment comment)
        {
            _mapper = mapper;
            _comment = comment;
        }

        public async Task<BaseCommandResponse> Handle(GetReportComment_R request, CancellationToken cancellationToken)
        {
            var responce = new BaseCommandResponse();


            var reportComment = await _comment.GetReportComments();

            if(!reportComment.Any())
            {
                responce.NotFound();
                return responce;
            }


            var Dto = _mapper.Map<List<Comment_Dto>>(reportComment);

            responce.Success(Dto);
            return responce;
        }
    }
}
