using FluentValidation;
using LearnHub.Application.Dto.Support.SupportStudent.common;

namespace LearnHub.Application.Validation.Support.SupportStudent.common
{
    public class ISupportStudent_V : AbstractValidator<ISupportStudent_Dto>
    {
        public ISupportStudent_V()
        {
            RuleFor(x => x.Question)
                .NotEmpty().WithMessage("The question cannot be empty.")
                .MaximumLength(2000).WithMessage("The question cannot be longer than 2000 characters.");
        }
    }
}
