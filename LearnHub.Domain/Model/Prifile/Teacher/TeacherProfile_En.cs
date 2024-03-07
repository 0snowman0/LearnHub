using LearnHub.Domain.Model.common;

namespace LearnHub.Domain.Model.Prifile.Teacher
{
    public class TeacherProfile_En : BaseEn_En
    {
        public  int UserId { get; set; }
        public string ImageName { get; set; } = null!;
        public string Description { get; set; } = null!;
    }
}
