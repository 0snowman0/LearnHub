using LearnHub.Application.Contracts.Support.SupportStudent;
using LearnHub.Domain.Model.Support;
using LearnHub.Persistence.Repositories.Generic;
using Microsoft.EntityFrameworkCore;

namespace LearnHub.Persistence.Repositories.Support
{
    public class SupportStudent_Rep : GenericRepository<SupportStudent_En>, ISupportStudent
    {
        private readonly Context_En _context;

        public SupportStudent_Rep(Context_En context)
            :base(context)
        {
            _context = context;
        }

        public async Task<List<SupportStudent_En>?> GetSupportStudentWithUserId(int userId)
        {
            return await _context.supportStudent_Ens.Where(p => p.UserId == userId).ToListAsync();
        }
    }
}
