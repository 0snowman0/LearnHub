using LearnHub.Application.Dto.Financial.Payment.Queries;
using System.Reflection.Metadata.Ecma335;

namespace LearnHub.Application.Dto.profile.Student.Queries
{
    public class Get_ProfileStudent_Dto 
    {
        public string UserName { get; set; } = null!;
        public string Email { get; set; } = null!;

        public List<Get_Payment_Dto> get_Payment_Dtos { get; set; } = null!;
    }
}
