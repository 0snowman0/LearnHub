using LearnHub.Application.Contracts.Course;
using LearnHub.Application.Dto.comment.command;
using LearnHub.Domain.Model.course;
using LearnHub.Persistence.Repositories.Generic;
using Microsoft.EntityFrameworkCore;
using System.Net.NetworkInformation;

namespace LearnHub.Persistence.Repositories.course
{
    public class Course_Rep : GenericRepository<Course_En>, ICourse
    {
        private readonly Context_En _context;

        public Course_Rep(Context_En context)
            :base(context)
        {
            _context = context;
        }

        public async Task<List<Course_En>?> GetWithTeacherId(int TeacherId)
        {
            return await _context.course_Ens.Where(p => p.TeacherId == TeacherId).ToListAsync();
        }
    }
}
