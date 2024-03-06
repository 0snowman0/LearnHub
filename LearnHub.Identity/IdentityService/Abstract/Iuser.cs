using LearnHub.Application.Contracts.Generic;
using LearnHub.Identity.Model.En;

namespace LearnHub.Identity.IdentityService.Abstract
{
    public interface Iuser : IGenericRepository<User_En>
    {
        Task<User_En> GetUserByEmail(string email);
    }
}
