using FluentValidation;
using LearnHub.Application.Dto.comment.command;
using LearnHub.Application.Validation.comment.common;

namespace LearnHub.Application.Validation.comment.command
{
    public class Update_Comment_V : AbstractValidator<Update_Comment_Dto>
    {
        public Update_Comment_V()
        {
            Include(new IComment_V());
        }
    }
}
