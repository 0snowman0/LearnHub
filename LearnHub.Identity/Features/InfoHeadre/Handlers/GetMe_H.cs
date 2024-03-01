using LearnHub.Identity.Features.InfoHeadre.Requests;
using LearnHub.Identity.IdentityService.Abstract;
using MediatR;

namespace LearnHub.Identity.Features.InfoHeadre.Handlers
{
    public class GetMe_H : IRequestHandler<GetMe_R, string>
    {
        private readonly IUserService _userService;

        public GetMe_H(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<string> Handle(GetMe_R request, CancellationToken cancellationToken)
        {
            return _userService.GetMyName();
        }
    }
}
