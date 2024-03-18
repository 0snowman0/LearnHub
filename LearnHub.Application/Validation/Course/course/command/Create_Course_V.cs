using FluentValidation;
using LearnHub.Application.Dto.Course.course.command;
using LearnHub.Application.Validation.Course.course.common;

namespace LearnHub.Application.Validation.Course.course.command
{
    public class Create_Course_V : AbstractValidator<Create_Course_Dto>
    {
        public Create_Course_V()
        {
            Include(new ICourse_V());
        }
    }
}
