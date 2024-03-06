using LearnHub.Domain.Model.common;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LearnHub.Domain.Model.FinancialSector
{
    public class Payment_En : BaseEn_En
    {
        public  int UserId { get; set; }
        public int CourseId { get; set; }

        [Required]
        public int Amount { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public string TrackingCode { get; set; } = null!;

        [Required]
        [DefaultValue(false)]
        public bool IsSucccess { get; set; }

    }
}

