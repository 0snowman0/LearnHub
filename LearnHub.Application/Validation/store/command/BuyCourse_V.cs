using FluentValidation;
using LearnHub.Application.Dto.store.command;

namespace LearnHub.Application.Validation.store.command
{
    public class BuyCourse_V : AbstractValidator<BuyCourse_Dto>
    {
        public BuyCourse_V()
        {
            // Assuming BaseDto_Dto has validations for common properties

            RuleFor(x => x.CourseId)
                .NotEmpty().WithMessage("The course ID cannot be empty.")
                .GreaterThan(0).WithMessage("The course ID must be greater than 0.");

            RuleFor(x => x.Price)
                .NotEmpty().WithMessage("The price cannot be empty.")
                .GreaterThan(0).WithMessage("The price must be greater than 0.");
        }
    }

}
