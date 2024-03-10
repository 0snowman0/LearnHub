using LearnHub.Domain.Model.common;

namespace LearnHub.Domain.Model.Permistion
{
    public class Permistion_En : BaseEn_En
    {
        public  int UserId { get; set; }
        public  bool Support { get; set; }
        public  bool Comment { get; set; }
        public  bool Financial { get; set; }
        public bool Course { get; set; }
    }
}
