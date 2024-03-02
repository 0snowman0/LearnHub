using AutoMapper;
using LearnHub.Application.Contracts.Support.SupportAdmin;
using LearnHub.Application.Dto.Support.SupportAdmin.Queries;
using LearnHub.Application.Features.SupportAdmin.Requests.Queries;
using LearnHub.Application.Responses;
using MediatR;

namespace LearnHub.Application.Features.SupportAdmin.Handlers.Queries
{
    public class GetAll_SupportAdmin_H : IRequestHandler<GetAll_SupportAdmin_R, BaseCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISupportAdmin _supportAdmin;

        public GetAll_SupportAdmin_H(IMapper mapper, ISupportAdmin supportAdmin)
        {
            _mapper = mapper;
            _supportAdmin = supportAdmin;
        }

        public async Task<BaseCommandResponse> Handle(GetAll_SupportAdmin_R request, CancellationToken cancellationToken)
        {
            var responce = new BaseCommandResponse();

            var SupportAdminAll = await _supportAdmin.GetAll();

            if(!SupportAdminAll.Any())
            {
                responce.Failure();
                responce.StatusCode = 404;
                responce.Errors = new List<string> {"not found any support" };
                return responce;
            }

            var SupportAdminDto = _mapper.Map <List<SupportAdmin_Dto>>(SupportAdminAll);

            responce.Success(SupportAdminDto);
            responce.StatusCode = 200;
            responce.Message = "success";
            return responce;
        }
    }
}
