using LearnHub.Application.Contracts.Profile;
using LearnHub.Domain.Model.Prifile.Teacher;
using LearnHub.Persistence.Repositories.Generic;
using Microsoft.EntityFrameworkCore;

namespace LearnHub.Persistence.Repositories.Profile
{
    public class ProfileTeacher_Rep : GenericRepository<TeacherProfile_En>, IProfileTeacher
    {
        private readonly Context_En _context;

        public ProfileTeacher_Rep(Context_En context)
            :base(context)
        {
            _context = context;
        }

        public async Task<TeacherProfile_En?> GetWithUserId(int userId)
        {
            return await _context.teacherProfile_Ens.FirstOrDefaultAsync(x => x.UserId == userId);
        }
    }
}
