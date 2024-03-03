using LearnHub.Application.Contracts.Generic;
using LearnHub.Domain.Model.Comment;

namespace LearnHub.Application.Contracts.comment
{
    public interface IComment : IGenericRepository<Comment_En>
    {
        Task<List<Comment_En>?> GetWithCourseId(int CourseId);
        Task<List<Comment_En>?> GetReportComments();
    }
}
