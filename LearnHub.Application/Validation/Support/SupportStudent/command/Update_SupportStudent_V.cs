using FluentValidation;
using LearnHub.Application.Dto.Support.SupportStudent.command;
using LearnHub.Application.Validation.Support.SupportStudent.common;

namespace LearnHub.Application.Validation.Support.SupportStudent.command
{
    public class Update_SupportStudent_V : AbstractValidator<Update_SupportStudent_Dto>
    {
        public Update_SupportStudent_V()
        {
            Include(new ISupportStudent_V());
        }
    }
}
