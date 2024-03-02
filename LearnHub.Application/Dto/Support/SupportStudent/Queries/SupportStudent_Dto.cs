using LearnHub.Application.Dto.common;

namespace LearnHub.Application.Dto.Support.SupportStudent.Queries
{
    public class SupportStudent_Dto : BaseDto_Dto
    {
        public  int UserId { get; set; }
        public string Question { get; set; }
        public DateTime Date { get; set; }
    }
}
