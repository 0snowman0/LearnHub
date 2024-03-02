using AutoMapper;
using LearnHub.Application.Contracts.Support.SupportAdmin;
using LearnHub.Application.Dto.Support.SupportAdmin.Queries;
using LearnHub.Application.Features.SupportAdmin.Requests.Queries;
using LearnHub.Application.Responses;
using MediatR;

namespace LearnHub.Application.Features.SupportAdmin.Handlers.Queries
{
    public class Get_SupportAdmin_H : IRequestHandler<Get_SupportAdmin_R, BaseCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISupportAdmin _supportAdmin;

        public Get_SupportAdmin_H(IMapper mapper, ISupportAdmin supportAdmin)
        {
            _mapper = mapper;
            _supportAdmin = supportAdmin;
        }

        public async Task<BaseCommandResponse> Handle(Get_SupportAdmin_R request, CancellationToken cancellationToken)
        {
            var responce = new BaseCommandResponse();

            var supportAdmin = await _supportAdmin.Get(request.Id);

            if (supportAdmin == null) 
            {
                responce.Failure();
                responce.StatusCode = 404;
                responce.Errors = new List<string> { $"not found any support massage with id:{request.Id}"};
                return responce;
            }


            var supportAdminDto = _mapper.Map<SupportAdmin_Dto>(supportAdmin);
            
            responce.Success(supportAdminDto);
            responce.StatusCode = 200;
            responce.Message = "success";
            return responce;
        }
    }
}
