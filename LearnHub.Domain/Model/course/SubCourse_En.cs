using LearnHub.Domain.Model.common;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearnHub.Domain.Model.course
{
    public class SubCourse_En : BaseEn_En
    {
        public  int NumberCourse { get; set; }
        public  string?  Description { get; set; }
        public  bool IsFree { get; set; }
        public string? ImageName { get; set; }

        [NotMapped]
        public IFormFile? ImageFile { get; set; }



        ///relation
        public  int courseId { get; set; }
        [ForeignKey("{courseId}")]
        public  Course_En? Course_En { get; set; }

    }
}
