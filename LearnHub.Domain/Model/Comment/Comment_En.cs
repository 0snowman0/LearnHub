using LearnHub.Domain.Model.common;
using System.ComponentModel.DataAnnotations;

namespace LearnHub.Domain.Model.Comment
{
    public class Comment_En : BaseEn_En
    {
        public  int CourseId { get; set; }
        public  int  UserId { get; set; }

        public string Content { get; set; } = null!;

        public  string?  Answer { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }
        
        [Required]
        public DateTime UpdatedAt { get; set; }

        [Required]
        public bool IsReport { get; set; }
    }
}
