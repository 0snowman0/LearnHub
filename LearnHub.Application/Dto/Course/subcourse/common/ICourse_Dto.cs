using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearnHub.Application.Dto.Course.subcourse.common
{
    public interface ISubCourse_Dto
    {
        public string? Description { get; set; }
        public bool IsFree { get; set; }
    }
}
