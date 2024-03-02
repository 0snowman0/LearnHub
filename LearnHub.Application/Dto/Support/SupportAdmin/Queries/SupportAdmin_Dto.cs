using LearnHub.Application.Dto.common;

namespace LearnHub.Application.Dto.Support.SupportAdmin.Queries
{
    public class SupportAdmin_Dto : BaseDto_Dto
    {
        public int AdminId { get; set; }
        public int SupportStudentId { get; set; }

        public string Answer { get; set; }

        public DateTime AnswerDate { get; set; }
        public DateTime UpdateAnswer { get; set; }
    }
}
