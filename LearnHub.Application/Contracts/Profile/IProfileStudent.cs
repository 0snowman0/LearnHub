using LearnHub.Application.Dto.profile.Student.Queries;
namespace LearnHub.Application.Contracts.Profile
{
    public interface IProfileStudent
    {
        Task<Get_ProfileStudent_Dto> GetProfileStudentWithUserId(int UserId);
   }
}
