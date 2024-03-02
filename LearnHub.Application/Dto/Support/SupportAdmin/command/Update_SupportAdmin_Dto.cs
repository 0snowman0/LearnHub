using LearnHub.Application.Dto.common;
using LearnHub.Application.Dto.Support.SupportAdmin.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnHub.Application.Dto.Support.SupportAdmin.command
{
    public class Update_SupportAdmin_Dto : BaseDto_Dto , ISupportAdmin_Dto
    {
        public int SupportStudentId { get; set; }
        public string Answer { get; set; }
    }
}
