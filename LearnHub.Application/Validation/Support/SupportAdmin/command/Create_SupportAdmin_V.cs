using FluentValidation;
using LearnHub.Application.Dto.Support.SupportAdmin.command;
using LearnHub.Application.Validation.Support.SupportAdmin.common;

namespace LearnHub.Application.Validation.Support.SupportAdmin.command
{
    public class Create_SupportAdmin_V : AbstractValidator<Create_SupportAdmin_Dto>
    {
        public Create_SupportAdmin_V()  
        {
            Include(new ISupportAdmin_V());
        }
    }
}
