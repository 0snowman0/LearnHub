using LearnHub.Application.Contracts.Generic;
using LearnHub.Domain.Model.Support;

namespace LearnHub.Application.Contracts.Support.SupportStudent
{
    public interface ISupportStudent : IGenericRepository<SupportStudent_En>
    {
        Task<List<SupportStudent_En>?> GetSupportStudentWithUserId(int userId);
    }
}
