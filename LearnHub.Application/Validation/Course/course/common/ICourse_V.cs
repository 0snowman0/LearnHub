using FluentValidation;
using LearnHub.Application.Dto.Course.course.common;

namespace LearnHub.Application.Validation.Course.course.common
{
    public class ICourse_V : AbstractValidator<ICourse_Dto>
    {
        public ICourse_V()
        {
            RuleFor(x => x.CourseName)
                .NotEmpty().WithMessage("The course name cannot be empty.")
                .MaximumLength(50).WithMessage("The course name cannot be longer than 50 characters.");

            RuleFor(x => x.CourseDescription)
                .NotEmpty().WithMessage("The course description cannot be empty.")
                .MaximumLength(3300).WithMessage("The course description cannot be longer than 3300 characters.");

            RuleFor(x => x.CourseLevel)
                .NotNull().WithMessage("The course level must be set.");
        }
    }

}
