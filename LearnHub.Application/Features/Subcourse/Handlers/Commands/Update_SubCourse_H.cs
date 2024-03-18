using AutoMapper;
using FluentValidation;
using LearnHub.Application.Contracts.Course;
using LearnHub.Application.Dto.Course.subcourse.command;
using LearnHub.Application.Features.Subcourse.Requests.Commands;
using LearnHub.Application.Responses;
using LearnHub.Application.Validation.Course.subcourse.command;
using MediatR;

namespace LearnHub.Application.Features.Subcourse.Handlers.Commands
{
    public class Update_SubCourse_H : IRequestHandler<Update_SubCourse_R, BaseCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISubCourse _subCourse;
        private readonly IValidator<Update_SubCourse_Dto> _validator;

        public Update_SubCourse_H(IMapper mapper, ISubCourse subCourse, IValidator<Update_SubCourse_Dto> validator)
        {
            _mapper = mapper;
            _subCourse = subCourse;
            _validator = validator;
        }

        public async Task<BaseCommandResponse> Handle(Update_SubCourse_R request, CancellationToken cancellationToken)
        {
            var responce = new BaseCommandResponse();

            #region Validation
            var Validate = await _validator.ValidateAsync(request.update_SubCourse);

            if (!Validate.IsValid)
            {
                responce.BadRequest(responce.ConvertValidationFailureToLisString(Validate.Errors));
                return responce;
            }
            #endregion


            var Target = await _subCourse.Get(request.update_SubCourse.Id);

            if (Target == null) 
            {
                responce.NotFound();
                responce.Errors = new List<string> {"not found subCourse" };
                return responce;
            }

            _mapper.Map(request.update_SubCourse , Target); 

            await _subCourse.Update(Target);

            responce.Success();
            responce.StatusCode = 204;
            return responce;
        }
    }
}
