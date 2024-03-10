using LearnHub.Application.Contracts.Generic;
using LearnHub.Domain.Model.Prifile.Teacher;

namespace LearnHub.Application.Contracts.Profile
{
    public interface IProfileTeacher : IGenericRepository<TeacherProfile_En>
    {
        Task<TeacherProfile_En?> GetWithUserId(int userId);
    }
}
