using FluentValidation;
using LearnHub.Application.Dto.Course.subcourse.command;
using LearnHub.Application.Validation.Course.subcourse.common;

namespace LearnHub.Application.Validation.Course.subcourse.command
{
    public class Update_SubCourse_V : AbstractValidator<Update_SubCourse_Dto>
    {
        public Update_SubCourse_V()
        {
            Include(new ISubCourse_V());
        }
    }
}
