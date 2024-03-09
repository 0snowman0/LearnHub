using LearnHub.Application.Contracts.payment;
using LearnHub.Domain.Model.FinancialSector;
using LearnHub.Persistence.Repositories.Generic;
using Microsoft.EntityFrameworkCore;

namespace LearnHub.Persistence.Repositories.payment
{
    public class Payment_Rep : GenericRepository<Payment_En>, Ipayment
    {
        private readonly Context_En _context;

        public Payment_Rep(Context_En context)
            :base(context)
        {
            _context = context;
        }

        public async Task<Payment_En?> GetPaymeentWithTrackingCode(string TrackingCode)
        {
            return await _context.payment_Ens.FirstOrDefaultAsync(p => p.TrackingCode == TrackingCode);
        }

        public async Task<List<Payment_En>?> GetPaymeentWithUserId(int UserId)
        {
            return await _context.payment_Ens.Where(p => p.UserId == UserId).ToListAsync();
        }
    }
}
