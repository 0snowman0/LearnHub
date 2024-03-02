using LearnHub.Domain.Enum;
using LearnHub.Domain.Model.common;
using System.ComponentModel.DataAnnotations;

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
        public string CourseImage { get; set; } = null!;
        [Required]
        public string CourseVideo { get; set; } = null!;
        [Required]
        [MaxLength(25)]
        public  CourseLevel_Em CourseLevel { get; set; } 
        [Required]
        public  int  NumberVideo  { get; set; }

        //relation
        public virtual ICollection<SubCourse_En> SubCourses { get; set; } = new List<SubCourse_En>();

    }
}
