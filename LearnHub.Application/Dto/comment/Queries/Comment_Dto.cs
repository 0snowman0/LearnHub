using LearnHub.Application.Dto.common;
using System.ComponentModel.DataAnnotations;

namespace LearnHub.Application.Dto.comment.Queries
{
    public class Comment_Dto : BaseDto_Dto
    {
        public int CourseId { get; set; }
        public int UserId { get; set; }

        public string Content { get; set; } = null!;

        public string? Answer { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public bool IsReport { get; set; }
    }
}
