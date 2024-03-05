using LearnHub.Application.Contracts.Generic;
using LearnHub.Domain.Model.course;

namespace LearnHub.Application.Contracts.Course
{
    public interface ISubCourse : IGenericRepository<SubCourse_En>
    {
        Task<List<SubCourse_En>?> GetWithCourseId(int CourseId);
    }
}
