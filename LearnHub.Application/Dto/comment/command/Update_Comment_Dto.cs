using LearnHub.Application.Dto.comment.common;
using LearnHub.Application.Dto.common;

namespace LearnHub.Application.Dto.comment.command
{
    public class Update_Comment_Dto : BaseDto_Dto , IComment_Dto 
    {
        public string Content { get; set; }
        public bool IsReport { get; set; }
    }
}
