using LearnHub.Application.Contracts.comment;
using LearnHub.Application.Dto.comment.command;
using LearnHub.Domain.Model.Comment;
using LearnHub.Persistence.Repositories.Generic;
using Microsoft.EntityFrameworkCore;

namespace LearnHub.Persistence.Repositories.comment
{
    public class Comment_Rep : GenericRepository<Comment_En>, IComment
    {
        private readonly Context_En _context;

        public Comment_Rep(Context_En context)
            :base(context)
        {
            _context = context;
        }

        public async Task<List<Comment_En>?> GetReportComments()
        {
            return await _context.comment_Ens.Where(p => p.IsReport == true).ToListAsync();
        }

        public async Task<List<Comment_En>?> GetWithCourseId(int CourseId)
        {
            return await _context.comment_Ens.Where(p => p.CourseId == CourseId).ToListAsync();
        }
    }
}
