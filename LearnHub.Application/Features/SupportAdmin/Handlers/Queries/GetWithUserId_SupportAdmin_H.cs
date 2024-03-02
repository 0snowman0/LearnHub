using AutoMapper;
using LearnHub.Application.Contracts.Support.SupportAdmin;
using LearnHub.Application.Dto.Support.SupportAdmin.Queries;
using LearnHub.Application.Features.SupportAdmin.Requests.Queries;
using LearnHub.Application.Responses;
using LearnHub.Domain.Model.Support;
using MediatR;
using System.Net.NetworkInformation;

namespace LearnHub.Application.Features.SupportAdmin.Handlers.Queries
{
    public class GetWithUserId_SupportAdmin_H : IRequestHandler<GetWithUserId_SupportAdmin_R, BaseCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISupportAdmin _supportAdmin;

        public GetWithUserId_SupportAdmin_H(IMapper mapper, ISupportAdmin supportAdmin)
        {
            _mapper = mapper;
            _supportAdmin = supportAdmin;
        }

        public async Task<BaseCommandResponse> Handle(GetWithUserId_SupportAdmin_R request, CancellationToken cancellationToken)
        {
            var responce = new BaseCommandResponse();

            var SupportAdmin = await _supportAdmin.GetWithAdminId(request.AdminId);

            if(SupportAdmin == null)
            {
                responce.Failure();
                responce.StatusCode = 404;
                responce.Errors = new List<string> {$"not found support massage with id:{request.AdminId}." };
                return responce;
            }


            var SupportAdminDto = _mapper.Map<List<SupportAdmin_Dto>>(SupportAdmin);

            responce.Success();
            responce.StatusCode = 200;
            responce.Data = SupportAdminDto;
            responce.Message = "success";
            return responce;
        }
    }
}
