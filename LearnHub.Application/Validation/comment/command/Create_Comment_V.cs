using FluentValidation;
using LearnHub.Application.Dto.comment.command;
using LearnHub.Application.Validation.comment.common;

namespace LearnHub.Application.Validation.comment.command
{
    public class Create_Comment_V : AbstractValidator<Create_Comment_Dto>
    {
        public Create_Comment_V()
        {
            Include(new IComment_V());

            RuleFor(x => x.CourseId).NotNull().NotEmpty();
        }
    }
}
