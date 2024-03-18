using FluentValidation;
using LearnHub.Application.Dto.Permistion.common;

namespace LearnHub.Application.Validation.Permistion.common
{
    public class IPermistion_V : AbstractValidator<IPermistion_Dto>
    {
        public IPermistion_V()
        {
            RuleFor(x => x.Support)
                .NotNull().WithMessage("The support permission must be set.");

            RuleFor(x => x.Comment)
                .NotNull().WithMessage("The comment permission must be set.");

            RuleFor(x => x.Financial)
                .NotNull().WithMessage("The financial permission must be set.");

            RuleFor(x => x.Course)
                .NotNull().WithMessage("The course permission must be set.");
        }
    }

}
