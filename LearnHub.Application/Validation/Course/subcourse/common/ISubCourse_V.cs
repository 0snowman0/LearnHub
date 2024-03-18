using FluentValidation;
using LearnHub.Application.Dto.Course.subcourse.common;

namespace LearnHub.Application.Validation.Course.subcourse.common
{
    public class ISubCourse_V : AbstractValidator<ISubCourse_Dto>
    {
        public ISubCourse_V()
        {
            // Description is nullable, so no need for NotEmpty
            RuleFor(x => x.Description)
                .MaximumLength(3300).WithMessage("The description cannot be longer than 3300 characters.");
        }
    }

}
