using LearnHub.Domain.Enum;
using LearnHub.Domain.Model.common;
using Microsoft.AspNetCore.Http;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearnHub.Domain.Model.course
{
    public class Course_En : BaseEn_En
    {
        [Required]
        public  int TeacherId { get; set; }
        
        [Required]
        public  bool AdminApproval { get; set; }
        
        [Required]
        [MaxLength(150)]
        public string CourseName { get; set; } = null!;
        
        [Required]
        [MaxLength(3000)]
        public string CourseDescription { get; set; } = null!;
        
        [Required]
        public string CourseImageName { get; set; } = null!;
        
        [Required]
        public string CourseVideoName { get; set; } = null!;
       
        [Required]
        [MaxLength(25)]
        public  CourseLevel_Em CourseLevel { get; set; }

        [Required]
        [DefaultValue(1)]
        public int NumberVideo { get; set; }

        [Required]
        public  int CoursePrice { get; set; }

        [NotMapped]
        public IFormFile? ImageFile { get; set; }
    }
}
