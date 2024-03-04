using LearnHub.Application.Dto.common;
using LearnHub.Domain.Enum;
using System.ComponentModel.DataAnnotations;

namespace LearnHub.Application.Dto.Course.course.Queries
{
    public class Course_Dto : BaseDto_Dto
    {
        public int TeacherId { get; set; }

        public bool AdminApproval { get; set; }

        public string CourseName { get; set; } = null!;

        public string CourseDescription { get; set; } = null!;

        public string CourseImageName { get; set; } = null!;

        public string CourseVideoName { get; set; } = null!;

        public CourseLevel_Em CourseLevel { get; set; }

        public int NumberVideo { get; set; }
    }
}
