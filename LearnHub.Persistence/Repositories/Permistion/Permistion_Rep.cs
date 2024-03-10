using LearnHub.Application.Contracts.permistion;
using LearnHub.Domain.Model.Permistion;
using LearnHub.Persistence.Repositories.Generic;
using Microsoft.EntityFrameworkCore;

namespace LearnHub.Persistence.Repositories.Permistion
{
    public class Permistion_Rep : GenericRepository<Permistion_En>, IPermistion
    {
        private readonly Context_En _context;

        public Permistion_Rep(Context_En context)
            :base(context) 
        {
            _context = context;
        }

        public async Task<Permistion_En?> GetByUserId(int userId)
        {
            return await _context.permistion_Ens.FirstOrDefaultAsync(x => x.UserId == userId);
        }
    }
}
