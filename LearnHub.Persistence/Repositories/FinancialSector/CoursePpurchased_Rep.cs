using LearnHub.Application.Contracts.FinancialSector;
using LearnHub.Domain.Model.FinancialSector;
using LearnHub.Persistence.Repositories.Generic;
using Microsoft.EntityFrameworkCore;

namespace LearnHub.Persistence.Repositories.FinancialSector
{
    public class CoursePpurchased_Rep : GenericRepository<CoursePpurchased_En>, ICoursePpurchased
    {
        private readonly Context_En _context;

        public CoursePpurchased_Rep(Context_En context)
            : base(context)
        {
            _context = context;
        }

        public async Task<CoursePpurchased_En?> GetWithCourseId(int courseId)
        {
            return await _context.coursePpurchased_Ens.Where(p => p.CourseId == courseId).FirstOrDefaultAsync();
        }

        public async Task<List<CoursePpurchased_En>?> GetWithUserId(int UserId)
        {
            return await _context.coursePpurchased_Ens.Where(p => p.Student_Id == UserId).ToListAsync();
        }
    }
}
