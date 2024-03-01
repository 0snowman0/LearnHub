using LearnHub.Identity.Enum;

namespace LearnHub.Identity.Model.Dto
{
    public class Register_Dto
    {
        public  string Email { get; set; }
        public  string  UserName { get; set; }
        public string Password { get; set; }
        public  Gender_Em gender_Em { get; set; }
    }
}
