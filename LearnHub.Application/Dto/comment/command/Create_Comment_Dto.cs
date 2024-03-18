using LearnHub.Application.Dto.comment.common;

namespace LearnHub.Application.Dto.comment.command
{
    public class Create_Comment_Dto : IComment_Dto
    {
        public int CourseId { get; set; }
        public string Content { get; set; } = string.Empty;
        public bool IsReport { get; set; }
    }
}
