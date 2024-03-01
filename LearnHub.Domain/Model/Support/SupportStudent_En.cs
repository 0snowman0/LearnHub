using LearnHub.Domain.Model.common;

namespace LearnHub.Domain.Model.Support
{
    public class SupportStudent_En : BaseEn_En
    {
        public  int UserId { get; set; }
        public  string Question { get; set; }
        public DateTime Date { get; set; }
    }
}
