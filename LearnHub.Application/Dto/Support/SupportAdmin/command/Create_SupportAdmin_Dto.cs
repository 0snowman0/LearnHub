using LearnHub.Application.Dto.Support.SupportAdmin.common;

namespace LearnHub.Application.Dto.Support.SupportAdmin.command
{
    public class Create_SupportAdmin_Dto : ISupportAdmin_Dto
    {
        public int SupportStudentId { get; set; }
        public string Answer { get; set; } = null!;
    }
}
