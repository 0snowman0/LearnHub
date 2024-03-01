using LearnHub.Domain.Model.common;

namespace LearnHub.Domain.Model.Support
{
    public class SupportAdmin_En : BaseEn_En
    {
        public  int  AdminId { get; set; }
        public  int  SupportStudentId { get; set; }

        public string Answer  { get; set; }

        public  DateTime AnswerDate { get; set; }
        public  DateTime UpdateAnswer { get; set; }
    }
}
