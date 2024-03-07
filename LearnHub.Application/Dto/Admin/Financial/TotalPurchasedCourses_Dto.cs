using LearnHub.Application.Dto.Course.course.Queries;

namespace LearnHub.Application.Dto.Admin.Financial
{
    public class TotalPurchasedCourses_Dto
    {
        public int  TotalPrice  { get; set; }
        public int  NumberCourse { get; set; }
        public  List<SubPurchasedCourses_Dto>? course_Dtos { get; set; }
    }
}
