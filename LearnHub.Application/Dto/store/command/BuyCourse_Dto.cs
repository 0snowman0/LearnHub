using LearnHub.Application.Dto.common;
using System.Reflection.Metadata.Ecma335;

namespace LearnHub.Application.Dto.store.command
{
    public class BuyCourse_Dto : BaseDto_Dto
    {
        public  int CourseId { get; set; }
        public  int Price { get; set; }
    }
}
