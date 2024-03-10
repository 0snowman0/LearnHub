using LearnHub.Identity.Enum;
using System.Reflection.Metadata.Ecma335;

namespace LearnHub.Identity.Model.Dto
{
    public class Register_Dto
    {
        public  string Email { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = null!;
        public  Gender_Em gender_Em { get; set; }
        public  Role_Em role { get; set; }
    }
}
