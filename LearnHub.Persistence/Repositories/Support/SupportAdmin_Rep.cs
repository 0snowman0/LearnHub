using LearnHub.Application.Contracts.Support.SupportAdmin;
using LearnHub.Domain.Model.Support;
using LearnHub.Persistence.Repositories.Generic;
using Microsoft.EntityFrameworkCore;
using System.Net.NetworkInformation;

namespace LearnHub.Persistence.Repositories.Support
{
    public class SupportAdmin_Rep : GenericRepository<SupportAdmin_En>, ISupportAdmin
    {
        private readonly Context_En _context;

        public SupportAdmin_Rep(Context_En context)
            :base(context)
        {
            _context = context;
        }

        public async Task<List<SupportAdmin_En>?> GetWithAdminId(int AdminId)
        {
            return await _context.supportAdmin_Ens.Where(p => p.AdminId == AdminId).ToListAsync();
        }
    }
}
