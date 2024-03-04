using LearnHub.Domain.Enum;

namespace LearnHub.Application.Dto.Course.course.common
{
    public interface ICourse_Dto
    {
        public string CourseName { get; set; }

        public string CourseDescription { get; set; }

        public CourseLevel_Em CourseLevel { get; set; }
    }
}
