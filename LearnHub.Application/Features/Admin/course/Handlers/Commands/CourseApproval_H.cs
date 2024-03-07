﻿using LearnHub.Application.Contracts.Course;
using LearnHub.Application.Features.Admin.course.Requests.Commands;
using LearnHub.Application.Responses;
using LearnHub.Domain.Model.course;
using MediatR;

namespace LearnHub.Application.Features.Admin.course.Handlers.Commands
{
    public class CourseApproval_H : IRequestHandler<CourseApproval_R, BaseCommandResponse>
    {
        private readonly ICourse _course;

        public CourseApproval_H(ICourse course)
        {
            _course = course;
        }

        public async Task<BaseCommandResponse> Handle(CourseApproval_R request, CancellationToken cancellationToken)
        {
            var responce = new BaseCommandResponse();

            var course = new Course_En();

            foreach(var courseId in request.CourseIds)
            {
                course = await _course.Get(courseId);

                if (course == null)
                {
                    responce.NotFound();
                    responce.Errors = new List<string> {$"not found course wiht id: {courseId}" };
                    return responce;
                }

                course.AdminApproval = true;

            }
            await _course.SaveAsync();

            responce.Success();
            responce.Message = "Done";
            return responce;
        }
    }
}
