using LearnHub.Application.Contracts.Generic;
using LearnHub.Identity.Model.En;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnHub.Identity.IdentityService.Abstract
{
    public interface Iuser : IGenericRepository<User_En>
    {
        Task<User_En> GetUserByEmail(string email);
    }
}
