using MediatR;

namespace LearnHub.Application.Features.Permistion.Requests.Queries
{
    public class CheckPermistion_R : IRequest<bool>
    {
        public int UesrId { get; set; }
        public object PermistionType { get; set; } = null!;
    }
}
