using FluentValidation;
using LearnHub.Application.Dto.Course.subcourse.command;
using LearnHub.Application.Validation.Course.subcourse.common;

namespace LearnHub.Application.Validation.Course.subcourse.command
{
    public class Create_SubCourse_V : AbstractValidator<Create_SubCourse_Dto>
    {
        public Create_SubCourse_V()
        {
            Include(new ISubCourse_V());

            RuleFor(x => x.courseId).NotNull().NotEmpty();
        }
    }
}
