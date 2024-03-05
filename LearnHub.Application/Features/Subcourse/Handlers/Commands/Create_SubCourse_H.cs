using AutoMapper;
using LearnHub.Application.Contracts.Course;
using LearnHub.Application.Features.Subcourse.Requests.Commands;
using LearnHub.Application.Responses;
using LearnHub.Domain.Model.course;
using LearnHub.File.Interface;
using MediatR;

namespace LearnHub.Application.Features.Subcourse.Handlers.Commands
{
    public class Create_SubCourse_H : IRequestHandler<Create_SubCourse_R, BaseCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISubCourse _subCourse;
        private readonly IFileService _fileService;
        public Create_SubCourse_H(IMapper mapper, ISubCourse subCourse, IFileService fileService)
        {
            _mapper = mapper;
            _subCourse = subCourse;
            _fileService = fileService;
        }

        public async Task<BaseCommandResponse> Handle(Create_SubCourse_R request, CancellationToken cancellationToken)
        {
            var responce = new BaseCommandResponse();

            var NewSubcourse = _mapper.Map<SubCourse_En>(request.create_SubCourse);


            var imageResult = _fileService.ReturnImageName(request.create_SubCourse.ImageFile);

            if (imageResult.Item1 == 1)
                NewSubcourse.ImageName = imageResult.Item2;

            await _subCourse.Add(NewSubcourse);

            responce.Success(NewSubcourse.Id);
            return responce;
        }
    }
}
