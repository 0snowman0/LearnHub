using FluentValidation;
using LearnHub.Application.Dto.Course.course.command;
using LearnHub.Application.Validation.Course.course.common;

namespace LearnHub.Application.Validation.Course.course.command
{
    public class Update_Course_V : AbstractValidator<Update_Course_Dto>
    {
        public Update_Course_V()
        {
            Include(new ICourse_V());
        }
    }
}
