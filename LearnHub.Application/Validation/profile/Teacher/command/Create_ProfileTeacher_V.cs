using FluentValidation;
using LearnHub.Application.Dto.profile.Teacher.command;

namespace LearnHub.Application.Validation.profile.Teacher.command
{
    public class Create_ProfileTeacher_V : AbstractValidator<Create_ProfileTeacher_Dto>
    {
        public Create_ProfileTeacher_V()
        {
            RuleFor(x => x.Description)
                .MaximumLength(500).WithMessage("The description cannot be longer than 500 characters.");
        }
    }

}
