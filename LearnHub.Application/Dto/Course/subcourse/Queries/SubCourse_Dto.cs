using LearnHub.Application.Dto.common;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearnHub.Application.Dto.Course.subcourse.Queries
{
    public class SubCourse_Dto : BaseDto_Dto
    {
        public int NumberCourse { get; set; }
        public string? Description { get; set; }
        public bool IsFree { get; set; }
        public string? ImageName { get; set; }
        public int courseId { get; set; }
    }
}
