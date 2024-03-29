﻿using LearnHub.Application.Dto.common;
using LearnHub.Application.Dto.Course.course.common;
using LearnHub.Domain.Enum;

namespace LearnHub.Application.Dto.Course.course.command
{
    public class Update_Course_Dto : BaseDto_Dto, ICourse_Dto
    {
        public string CourseName { get; set; } = string.Empty;

        public string CourseDescription { get; set; } = string.Empty;

        public CourseLevel_Em CourseLevel { get; set; }
    }
}
