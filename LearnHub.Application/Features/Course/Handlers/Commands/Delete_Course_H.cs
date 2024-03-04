using AutoMapper;
using LearnHub.Application.Contracts.Course;
using LearnHub.Application.Features.Course.Requests.Commands;
using LearnHub.Application.Responses;
using MediatR;

namespace LearnHub.Application.Features.Course.Handlers.Commands
{
    public class Delete_Course_H : IRequestHandler<Delete_Course_R, BaseCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICourse _course;

        public Delete_Course_H(IMapper mapper, ICourse course)
        {
            _mapper = mapper;
            _course = course;
        }

        public async Task<BaseCommandResponse> Handle(Delete_Course_R request, CancellationToken cancellationToken)
        {
            var responce = new BaseCommandResponse();

            await _course.Delete(request.Ids);

            responce.Success();
            responce.Message = "Deleted";
            return responce;
        }
    }
}
