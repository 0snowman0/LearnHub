using LearnHub.Application.Contracts.Generic;
using LearnHub.Domain.Model.FinancialSector;

namespace LearnHub.Application.Contracts.FinancialSector
{
    public interface ICoursePpurchased : IGenericRepository<CoursePpurchased_En>
    {
        Task<CoursePpurchased_En?> GetWithCourseId(int courseId);
        Task<List<CoursePpurchased_En>?> GetWithUserId(int UserId);
    }
}
