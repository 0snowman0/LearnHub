using AutoMapper;
using FluentValidation;
using LearnHub.Application.Contracts.Course;
using LearnHub.Application.Dto.Course.course.command;
using LearnHub.Application.Features.Course.Requests.Commands;
using LearnHub.Application.Responses;
using LearnHub.Application.Validation.Course.course.command;
using MediatR;

namespace LearnHub.Application.Features.Course.Handlers.Commands
{
    public class Update_Course_H : IRequestHandler<Update_Course_R, BaseCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICourse _course;
        private readonly IValidator<Update_Course_Dto> _validator;

        public Update_Course_H(IMapper mapper, ICourse course, IValidator<Update_Course_Dto> validator)
        {
            _mapper = mapper;
            _course = course;
            _validator = validator;
        }

        public Task<BaseCommandResponse> Handle(Update_Course_R request, CancellationToken cancellationToken)
        {

            return null;
        }
    }
}
