using AutoMapper;
using AutoMapper.Configuration.Annotations;
using LearnHub.Application.Contracts.Support.SupportAdmin;
using LearnHub.Application.Features.SupportAdmin.Requests.Commands;
using LearnHub.Application.Responses;
using LearnHub.Domain.Model.course;
using LearnHub.Domain.Model.Support;
using MediatR;

namespace LearnHub.Application.Features.SupportAdmin.Handlers.Commands
{
    public class Create_SupportAdmin_H : IRequestHandler<Create_SupportAdmin_R, BaseCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISupportAdmin _supportAdmin;

        public Create_SupportAdmin_H(IMapper mapper, ISupportAdmin supportAdmin)
        {
            _mapper = mapper;
            _supportAdmin = supportAdmin;
        }

        public async Task<BaseCommandResponse> Handle(Create_SupportAdmin_R request, CancellationToken cancellationToken)
        {
            var responce = new BaseCommandResponse();

            var NewSupportAdmin = _mapper.Map<SupportAdmin_En>(request.create_SupportAdmin_Dto);

            NewSupportAdmin.AdminId = request.AdminId;
            NewSupportAdmin.AnswerDate = DateTime.Now;
            NewSupportAdmin.UpdateAnswer = DateTime.Now;

            await _supportAdmin.Add(NewSupportAdmin);

            responce.Success(NewSupportAdmin.Id);
            responce.StatusCode = 200;
            responce.Message = "Created";
            return responce;
        }
    }
}
