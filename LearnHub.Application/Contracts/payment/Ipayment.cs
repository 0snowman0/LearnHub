using LearnHub.Application.Contracts.Generic;
using LearnHub.Domain.Model.FinancialSector;

namespace LearnHub.Application.Contracts.payment
{
    public interface Ipayment : IGenericRepository<Payment_En>
    {
        Task<Payment_En?> GetPaymeentWithTrackingCode(string TrackingCode);
    }
}
