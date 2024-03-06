using LearnHub.Application.Contracts.FinancialSector;
using LearnHub.Domain.Model.FinancialSector;
using LearnHub.Persistence.Repositories.Generic;

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
    }
}
