using LearnHub.Domain.Model.Comment;
using LearnHub.Domain.Model.course;
using LearnHub.Domain.Model.FinancialSector;
using LearnHub.Domain.Model.Support;
using LearnHub.Identity.Model.En;
using Microsoft.EntityFrameworkCore;

namespace LearnHub.Persistence
{
    public class Context_En : DbContext
    {
        public Context_En(DbContextOptions<Context_En> options)
            : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .ApplyConfigurationsFromAssembly(typeof(Context_En).Assembly);
        }


        public  DbSet<Course_En> course_Ens  { get; set; }
        public  DbSet<Payment_En> payment_Ens  { get; set; }
        public  DbSet<User_En> user_Ens  { get; set; }
        public  DbSet<RefreshToken> refreshTokens  { get; set; }
        public  DbSet<SupportAdmin_En> supportAdmin_Ens { get; set; }
        public  DbSet<SupportStudent_En> supportStudent_Ens  { get; set; }
        public  DbSet<SubCourse_En> subCourse_Ens  { get; set; }
        public  DbSet<Comment_En> comment_Ens  { get; set; }
        public  DbSet<CoursePpurchased_En> coursePpurchased_Ens { get; set; }

    }
}
