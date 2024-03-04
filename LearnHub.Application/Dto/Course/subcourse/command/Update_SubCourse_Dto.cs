using LearnHub.Application.Dto.common;
using LearnHub.Application.Dto.Course.subcourse.common;

namespace LearnHub.Application.Dto.Course.subcourse.command
{
    public class Update_SubCourse_Dto :BaseDto_Dto ,  ISubCourse_Dto
    {
        public string? Description { get; set; }
        public bool IsFree { get; set; }
    }
}
