using LearnHub.Application.Contracts.Generic;
using LearnHub.Domain.Model.course;

namespace LearnHub.Application.Contracts.Course
{
    public interface ICourse : IGenericRepository<Course_En>
    {
        Task<List<Course_En>?> GetWithTeacherId(int TeacherId);
        Task<string> ReturnTeacherName(int CourseId);
    }
}
