using AutoMapper;
using LearnHub.Application.Contracts.Course;
using LearnHub.Application.Features.Subcourse.Requests.Commands;
using LearnHub.Application.Responses;
using MediatR;

namespace LearnHub.Application.Features.Subcourse.Handlers.Commands
{
    public class Delete_SubCourse_H : IRequestHandler<Delete_SubCourse_R, BaseCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISubCourse _subCourse;

        public Delete_SubCourse_H(IMapper mapper, ISubCourse subCourse)
        {
            _mapper = mapper;
            _subCourse = subCourse;
        }

        public async Task<BaseCommandResponse> Handle(Delete_SubCourse_R request, CancellationToken cancellationToken)
        {
            var responce = new BaseCommandResponse();

            await _subCourse.Delete(request.Ids);

            responce.Success();
            responce.StatusCode = 204;
            responce.Message = "Deleted";
            return responce;
        }
    }
}
