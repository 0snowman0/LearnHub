using FluentValidation;
using LearnHub.Application.Dto.Support.SupportAdmin.common;

namespace LearnHub.Application.Validation.Support.SupportAdmin.common
{
    public class ISupportAdmin_V : AbstractValidator<ISupportAdmin_Dto>
    {
        public ISupportAdmin_V()
        {
            RuleFor(x => x.SupportStudentId)
                .NotEmpty().WithMessage("The support student ID cannot be empty.")
                .GreaterThan(0).WithMessage("The support student ID must be greater than 0.");

            RuleFor(x => x.Answer)
                .NotEmpty().WithMessage("The answer cannot be empty.")
                .MaximumLength(2000).WithMessage("The answer cannot be longer than 2000 characters.");
        }
    }

}
