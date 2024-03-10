using LearnHub.Application.Dto.Permistion.command;
using LearnHub.Application.Dto.Permistion.Queries;
using LearnHub.Identity.Enum;

namespace LearnHub.Identity.Model.Dto
{
    public class RegisterAdmin_Dto
    {
        public string Email { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = null!;
        public Gender_Em gender_Em { get; set; }
        public  Role_Em  role_Em { get; set; }

        public  Create_Permistion_Dto permistion_Dtos { get; set; } = new Create_Permistion_Dto();
    }
}
