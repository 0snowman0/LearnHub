using FluentValidation;
using LearnHub.Application.Dto.Support.SupportStudent.command;
using LearnHub.Application.Validation.Support.SupportStudent.common;

namespace LearnHub.Application.Validation.Support.SupportStudent.command
{
    public class Create_SupportStudent_V : AbstractValidator<Create_SupportStudent_Dto>
    {
        public Create_SupportStudent_V()
        {
            Include(new ISupportStudent_V());
        }
    }
}
