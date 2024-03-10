using LearnHub.Application.Contracts.Generic;
using LearnHub.Domain.Model.Permistion;

namespace LearnHub.Application.Contracts.permistion
{
    public interface IPermistion : IGenericRepository<Permistion_En>
    {
        Task<Permistion_En?> GetByUserId(int userId);
    }
}
