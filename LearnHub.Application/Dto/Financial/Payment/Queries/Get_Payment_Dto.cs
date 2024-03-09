using LearnHub.Application.Dto.common;

namespace LearnHub.Application.Dto.Financial.Payment.Queries
{
    public class Get_Payment_Dto : BaseDto_Dto
    {
        public int UserId { get; set; }
        public int CourseId { get; set; }

        public int Amount { get; set; }

        public DateTime Date { get; set; }

        public string TrackingCode { get; set; } = null!;

        public bool IsSucccess { get; set; }

    }
}
