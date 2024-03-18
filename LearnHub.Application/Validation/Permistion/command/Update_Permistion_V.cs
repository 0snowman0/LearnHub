using FluentValidation;
using LearnHub.Application.Dto.Permistion.command;
using LearnHub.Application.Validation.Permistion.common;

namespace LearnHub.Application.Validation.Permistion.command
{
    public class Update_Permistion_V : AbstractValidator<Update_Permistion_Dto>
    {
        public Update_Permistion_V()
        {
            Include(new IPermistion_V());
        }
    }
}
