    using AutoMapper;
using LearnHub.Application.Contracts.Support.SupportAdmin;
using LearnHub.Application.Features.SupportAdmin.Requests.Commands;
using LearnHub.Application.Responses;
using MediatR;

namespace LearnHub.Application.Features.SupportAdmin.Handlers.Commands
{
    public class Delete_SupportAdmin_H : IRequestHandler<Delete_SupportAdmin_R, BaseCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISupportAdmin _supportAdmin;

        public Delete_SupportAdmin_H(IMapper mapper, ISupportAdmin supportAdmin)
        {
            _mapper = mapper;
            _supportAdmin = supportAdmin;
        }

        public async Task<BaseCommandResponse> Handle(Delete_SupportAdmin_R request, CancellationToken cancellationToken)
        {
            var responce = new BaseCommandResponse();

            await _supportAdmin.Delete(request.Ids);

            responce.Success();
            responce.Message = "Deleted Successfully";
            responce.StatusCode = 204;
            return responce;
        }
    }
}
