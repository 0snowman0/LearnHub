using System.Reflection.Metadata.Ecma335;

namespace LearnHub.Application.Dto.profile.Student.command
{
    public class Update_ProfileStudent_Dto
    {
        public  int UserId { get; set; }
        public  string Email { get; set; } = null!;
        public string UserName { get; set; } = null!;
    }
}
