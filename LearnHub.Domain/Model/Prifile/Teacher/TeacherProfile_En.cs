using LearnHub.Domain.Model.common;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearnHub.Domain.Model.Prifile.Teacher
{
    public class TeacherProfile_En : BaseEn_En
    {
        public  int UserId { get; set; }
        public string ImageName { get; set; } = null!;
        public string Description { get; set; } = null!;

        [NotMapped]
        public IFormFile? ImageFile { get; set; }
    }
}
