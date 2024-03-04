using LearnHub.Application.Dto.common;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearnHub.Application.Dto.Course.subcourse.command
{
    public class UpdateVedio_SubCourse_Dto : BaseDto_Dto
    {
        [NotMapped]
        public IFormFile? ImageFile { get; set; }
    }
}
