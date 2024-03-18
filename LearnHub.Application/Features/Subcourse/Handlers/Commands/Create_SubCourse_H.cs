using AutoMapper;
using FluentValidation;
using LearnHub.Application.Contracts.Course;
using LearnHub.Application.Dto.Course.subcourse.command;
using LearnHub.Application.Features.Subcourse.Requests.Commands;
using LearnHub.Application.Responses;
using LearnHub.Application.Validation.Course.subcourse.command;
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
        private readonly IValidator<Create_SubCourse_Dto> _validator;

        public Create_SubCourse_H(IMapper mapper, ISubCourse subCourse, IFileService fileService, IValidator<Create_SubCourse_Dto> validator)
        {
            _mapper = mapper;
            _subCourse = subCourse;
            _fileService = fileService;
            _validator = validator;
        }

        public async Task<BaseCommandResponse> Handle(Create_SubCourse_R request, CancellationToken cancellationToken)
        {
            var responce = new BaseCommandResponse();


            #region Validation
            var Validate = await _validator.ValidateAsync(request.create_SubCourse);

            if (!Validate.IsValid)
            {
                responce.BadRequest(responce.ConvertValidationFailureToLisString(Validate.Errors));
                return responce;
            }
            #endregion


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
