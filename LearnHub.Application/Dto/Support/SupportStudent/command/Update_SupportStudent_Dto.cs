using LearnHub.Application.Dto.common;
using LearnHub.Application.Dto.Support.SupportStudent.common;

namespace LearnHub.Application.Dto.Support.SupportStudent.command
{
    public class Update_SupportStudent_Dto :BaseDto_Dto ,  ISupportStudent_Dto
    {

        public string Question { get; set; }

    }
}
