using LearnHub.Identity.IdentityService.Abstract;
using LearnHub.Identity.Model.En;
using LearnHub.Persistence.Repositories.Generic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnHub.Persistence.Repositories.Identity
{
    public class User_Rep : GenericRepository<User_En>, Iuser
    {
        private readonly Context_En _context;

        public User_Rep(Context_En context)
            :base(context)
        {
            _context = context;
        }

        public async Task<User_En?> GetUserByEmail(string email)
        {
            return await _context.user_Ens.FirstOrDefaultAsync(p => p.Email == email);
        }
    }
}
