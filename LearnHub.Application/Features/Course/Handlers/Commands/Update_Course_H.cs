using AutoMapper;
using LearnHub.Application.Contracts.Course;
using LearnHub.Application.Features.Course.Requests.Commands;
using LearnHub.Application.Responses;
using MediatR;

namespace LearnHub.Application.Features.Course.Handlers.Commands
{
    public class Update_Course_H : IRequestHandler<Update_Course_R, BaseCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICourse _course;

        public Update_Course_H(IMapper mapper, ICourse course)
        {
            _mapper = mapper;
            _course = course;
        }

        public Task<BaseCommandResponse> Handle(Update_Course_R request, CancellationToken cancellationToken)
        {
            return null;
        }
    }
}
