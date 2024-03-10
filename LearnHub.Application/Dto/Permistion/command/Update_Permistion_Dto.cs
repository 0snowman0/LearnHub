using LearnHub.Application.Dto.Permistion.common;

namespace LearnHub.Application.Dto.Permistion.command
{
    public class Update_Permistion_Dto : IPermistion_Dto
    {
        public bool Support { get; set; }
        public bool Comment { get; set; }
        public bool Financial { get; set; }
        public bool Course { get; set; }
    }
}
