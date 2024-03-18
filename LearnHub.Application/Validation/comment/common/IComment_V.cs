using FluentValidation;
using LearnHub.Application.Dto.comment.common;

namespace LearnHub.Application.Validation.comment.common
{
    public class IComment_V : AbstractValidator<IComment_Dto>
    {
        public IComment_V()
        {
            RuleFor(x => x.Content)
                .NotEmpty().WithMessage("The comment content cannot be empty.")
                .MaximumLength(500).WithMessage("The comment content cannot be longer than 500 characters.");

            // IsReport does not require specific validation as it's a boolean field
        }
    }

}
