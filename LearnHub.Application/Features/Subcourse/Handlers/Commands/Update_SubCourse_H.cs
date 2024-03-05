using AutoMapper;
using LearnHub.Application.Contracts.Course;
using LearnHub.Application.Features.Subcourse.Requests.Commands;
using LearnHub.Application.Responses;
using MediatR;

namespace LearnHub.Application.Features.Subcourse.Handlers.Commands
{
    public class Update_SubCourse_H : IRequestHandler<Update_SubCourse_R, BaseCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISubCourse _subCourse;

        public Update_SubCourse_H(IMapper mapper, ISubCourse subCourse)
        {
            _mapper = mapper;
            _subCourse = subCourse;
        }

        public async Task<BaseCommandResponse> Handle(Update_SubCourse_R request, CancellationToken cancellationToken)
        {
            var responce = new BaseCommandResponse();

            var Target = await _subCourse.Get(request.update_SubCourse.Id);

            if (Target == null) 
            {
                responce.NotFound();
                responce.Errors = new List<string> {"not found subCourse" };
                return responce;
            }

            _mapper.Map(request.update_SubCourse , Target); 

            await _subCourse.Update(Target);

            responce.Success();
            responce.StatusCode = 204;
            return responce;
        }
    }
}
