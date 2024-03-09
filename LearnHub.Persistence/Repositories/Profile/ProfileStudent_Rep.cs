using LearnHub.Application.Contracts.Profile;
using LearnHub.Application.Dto.profile.Student.Queries;
using Microsoft.EntityFrameworkCore;

namespace LearnHub.Persistence.Repositories.Profile
{
    public class ProfileStudent_Rep : IProfileStudent
    {
        private readonly Context_En _context;

        public ProfileStudent_Rep(Context_En context)
        {
            _context = context;
        }

        public async Task<Get_ProfileStudent_Dto> GetProfileStudentWithUserId(int UserId)
        {
            var User = await _context.user_Ens.FirstOrDefaultAsync(p => p.Id == UserId);

            if (User == null)
            {
                return null;
            }
            var Get_ProfileStudent_Dto = new Get_ProfileStudent_Dto()
            {
                UserName = User.Username,
                Email = User.Email
            };

            return Get_ProfileStudent_Dto;
        }
    }
}
