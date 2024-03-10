using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearnHub.Application.Dto.profile.Teacher.command
{
    public class Create_ProfileTeacher_Dto
    {
        public string Description { get; set; } = null!;

        [NotMapped]
        public IFormFile? ImageFile { get; set; }
    }
}
