using FluentValidation;
using LearnHub.Application.Dto.profile.Student.command;

namespace LearnHub.Application.Validation.profile.Student.command
{
    public class Update_ProfileStudent_V : AbstractValidator<Update_ProfileStudent_Dto>
    {
        public Update_ProfileStudent_V()
        {
            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("The user ID cannot be empty.")
                .GreaterThan(0).WithMessage("The user ID must be greater than 0.");

            RuleFor(x => x.Email)
                .EmailAddress().WithMessage("The email address is invalid.")
                .NotEmpty().WithMessage("The email address cannot be empty.");

            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("The username cannot be empty.");
        }
    }

}
