using LearnHub.Application.Dto.Course.course.common;
using LearnHub.Domain.Enum;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearnHub.Application.Dto.Course.course.command
{
    public class Create_Course_Dto : ICourse_Dto
    {
        public string CourseName { get; set; } = string.Empty;

        public string CourseDescription { get; set; } = string.Empty;

        public CourseLevel_Em CourseLevel { get; set; }

        [NotMapped]
        public List<IFormFile>? ImageFiles { get; set; }
    }
}
