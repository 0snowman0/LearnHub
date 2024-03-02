using LearnHub.Application.Contracts.Generic;
using LearnHub.Domain.Model.Support;

namespace LearnHub.Application.Contracts.Support.SupportAdmin
{
    public interface ISupportAdmin : IGenericRepository<SupportAdmin_En>
    {
        Task<List<SupportAdmin_En>?> GetWithAdminId(int AdminId);
    }
}
