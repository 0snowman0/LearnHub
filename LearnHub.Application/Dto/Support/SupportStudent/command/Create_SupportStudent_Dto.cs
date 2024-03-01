using LearnHub.Application.Dto.Support.SupportStudent.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnHub.Application.Dto.Support.SupportStudent.command
{
    public class Create_SupportStudent_Dto : ISupportStudent_Dto
    {
        public string Question { get; set; }

    }
}
