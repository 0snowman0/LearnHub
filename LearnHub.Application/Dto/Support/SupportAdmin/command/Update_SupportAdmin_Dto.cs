using LearnHub.Application.Dto.common;
using LearnHub.Application.Dto.Support.SupportAdmin.common;

namespace LearnHub.Application.Dto.Support.SupportAdmin.command
{
    public class Update_SupportAdmin_Dto : BaseDto_Dto , ISupportAdmin_Dto
    {
        public int SupportStudentId { get; set; }
        public string Answer { get; set; } = null!;
    }
}
