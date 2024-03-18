using FluentValidation;
using LearnHub.Application.Dto.Support.SupportAdmin.command;
using LearnHub.Application.Validation.Support.SupportAdmin.common;

namespace LearnHub.Application.Validation.Support.SupportAdmin.command
{
    public class Update_SupportAdmin_V : AbstractValidator<Update_SupportAdmin_Dto>
    {
        public Update_SupportAdmin_V()
        {
            Include(new ISupportAdmin_V());
        }
    }
}
