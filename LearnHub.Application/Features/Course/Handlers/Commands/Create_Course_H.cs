using AutoMapper;
using LearnHub.Application.Contracts.Course;
using LearnHub.Application.Features.Course.Requests.Commands;
using LearnHub.Application.Responses;
using LearnHub.Domain.Model.course;
using LearnHub.File.Interface;
using MediatR;

namespace LearnHub.Application.Features.Course.Handlers.Commands
{
    public class Create_Course_H : IRequestHandler<Create_Course_R, BaseCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICourse _course;
        private readonly IFileService _fileService;

        public Create_Course_H(IMapper mapper, ICourse course, IFileService fileService)
        {
            _mapper = mapper;
            _course = course;
            _fileService = fileService;
        }

        public async Task<BaseCommandResponse> Handle(Create_Course_R request, CancellationToken cancellationToken)
        {
            var responce = new BaseCommandResponse();

            var NewCousre = _mapper.Map<Course_En>(request.create_Course_Dto);

            NewCousre.TeacherId = request.TeacherId;

            var imageResult = _fileService.ReturnImageName(request.create_Course_Dto.ImageFiles[0]);
            
            if (imageResult.Item1 == 1)
                NewCousre.CourseImageName = imageResult.Item2;

            var imageResult2 = _fileService.ReturnImageName(request.create_Course_Dto.ImageFiles[1]);

            if (imageResult.Item1 == 1)
                NewCousre.CourseVideoName = imageResult2.Item2;

            await _course.Add(NewCousre);

            responce.Success(NewCousre.Id);
            responce.Message = "created";
            return responce;
        }
    }
}
