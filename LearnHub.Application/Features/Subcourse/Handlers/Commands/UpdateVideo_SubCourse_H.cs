using AutoMapper;
using LearnHub.Application.Contracts.Course;
using LearnHub.Application.Features.Subcourse.Requests.Commands;
using LearnHub.Application.Responses;
using LearnHub.File.Interface;
using MediatR;

namespace LearnHub.Application.Features.Subcourse.Handlers.Commands
{
    public class UpdateVideo_SubCourse_H : IRequestHandler<UpdateVideo_SubCourse_R, BaseCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISubCourse _subCourse;
        private readonly IFileService _fileService;
        public UpdateVideo_SubCourse_H(IMapper mapper, ISubCourse subCourse, IFileService fileService)
        {
            _mapper = mapper;
            _subCourse = subCourse;
            _fileService = fileService;
        }

        public async Task<BaseCommandResponse> Handle(UpdateVideo_SubCourse_R request, CancellationToken cancellationToken)
        {
            var responce = new BaseCommandResponse();

            var Target = await _subCourse.Get(request.updateVideo_SubCourse.Id);

            if (Target == null)
            {
                responce.NotFound();
                responce.Errors = new List<string> { "not found subCourse" };
                return responce;
            }

            var imageResult = _fileService.ReturnImageName(request.updateVideo_SubCourse.ImageFile);

            if (imageResult.Item1 == 1)
                Target.ImageName = imageResult.Item2;

            await _subCourse.SaveAsync();

            responce.Success();
            responce.StatusCode = 204;
            return responce;
        }
    }
}
