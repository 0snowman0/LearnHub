using LearnHub.Application.Dto.common;

namespace LearnHub.Application.Dto.Permistion.Queries
{
    public class Permistion_Dto : BaseDto_Dto
    {
        public bool Support { get; set; }
        public bool Comment { get; set; }
        public bool Financial { get; set; }
        public bool Course { get; set; }
    }
}
