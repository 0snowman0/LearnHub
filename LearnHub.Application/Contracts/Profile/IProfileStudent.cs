using LearnHub.Application.Dto.profile.Student.Queries;
using LearnHub.Domain.Model.Prifile.Student;

namespace LearnHub.Application.Contracts.Profile
{
    public interface IProfileStudent
    {
        Task<Get_ProfileStudent_Dto> GetProfileStudentWithUserId(int UserId);
   }
}
