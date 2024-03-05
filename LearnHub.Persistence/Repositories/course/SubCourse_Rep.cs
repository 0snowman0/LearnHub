using LearnHub.Application.Contracts.Course;
using LearnHub.Domain.Model.course;
using LearnHub.Persistence.Repositories.Generic;
using Microsoft.EntityFrameworkCore;

namespace LearnHub.Persistence.Repositories.course
{
    public class SubCourse_Rep : GenericRepository<SubCourse_En>, ISubCourse
    {
        private readonly Context_En _context;

        public SubCourse_Rep(Context_En context)
            :base(context)
        {
            _context = context;
        }

        public async Task<List<SubCourse_En>?> GetWithCourseId(int CourseId)
        {
            return await _context.subCourse_Ens.Where(p => p.courseId == CourseId).ToListAsync();
        }
    }
}
