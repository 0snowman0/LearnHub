using LearnHub.Application.Contracts.Profile;
using LearnHub.Domain.Model.Prifile.Admin;
using LearnHub.Persistence.Repositories.Generic;

namespace LearnHub.Persistence.Repositories.Profile
{
    public class AdminProfile_Rep : GenericRepository<AdminProfile_En> , IAdminProfile
    {
        private readonly Context_En _context;

        public AdminProfile_Rep(Context_En context)
            :base(context)
        {
            _context = context;
        }
    }
}
