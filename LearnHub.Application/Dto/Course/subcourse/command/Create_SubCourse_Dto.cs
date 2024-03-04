using LearnHub.Application.Dto.Course.course.common;
using LearnHub.Application.Dto.Course.subcourse.common;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearnHub.Application.Dto.Course.subcourse.command
{
    public class Create_SubCourse_Dto : ISubCourse_Dto
    {
        public string? Description { get; set; }
        public bool IsFree { get; set; }
        public int courseId { get; set; }
        [NotMapped]
        public IFormFile? ImageFile { get; set; }
    }
}
