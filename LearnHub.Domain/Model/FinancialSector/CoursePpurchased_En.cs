using LearnHub.Domain.Model.common;

namespace LearnHub.Domain.Model.FinancialSector
{
    public class CoursePpurchased_En : BaseEn_En
    {
        public  int Student_Id { get; set; }
        public  int CourseId { get; set; }
        public  DateTime purchaseDate { get; set; }
    }
}
