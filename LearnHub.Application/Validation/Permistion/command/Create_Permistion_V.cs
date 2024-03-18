using FluentValidation;
using LearnHub.Application.Dto.Permistion.command;
using LearnHub.Application.Validation.Permistion.common;

namespace LearnHub.Application.Validation.Permistion.command
{
    public class Create_Permistion_V : AbstractValidator<Create_Permistion_Dto>
    {
        public Create_Permistion_V()
        {
            Include(new IPermistion_V());
        }
    }
}
