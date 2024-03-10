using AutoMapper.Configuration.Annotations;
using LearnHub.Application.Contracts.permistion;
using LearnHub.Application.Features.Permistion.Requests.Queries;
using LearnHub.Application.Responses;
using LearnHub.Domain.Model.Comment;
using LearnHub.Domain.Model.course;
using LearnHub.Domain.Model.Support;
using MediatR;
using System.Reflection.Metadata.Ecma335;

namespace LearnHub.Application.Features.Permistion.Handlers.Queries
{
    public class CheckPermistion_H : IRequestHandler<CheckPermistion_R, bool>
    {
        private readonly IPermistion _permistion;

        public CheckPermistion_H(IPermistion permistion)
        {
            this._permistion = permistion;
        }

        public async Task<bool> Handle(CheckPermistion_R request, CancellationToken cancellationToken)
        {
            var permision = await _permistion.GetByUserId(request.UesrId);

            if (permision == null) 
                return false;

            object PT = request.PermistionType;



            if (PT.GetType() == typeof(SupportAdmin_En))
                if(permision.Support == true)
                    return true;
                else
                {
                    return false;
                }



            if (PT.GetType() == typeof(Comment_En))
                if (permision.Comment == true)
                    return true;
                else
                {
                    return false;
                }



            if (PT.GetType() == typeof(Course_En))
                if (permision.Course == true)
                    return true;
                else
                {
                    return false;
                }


            if(permision.Financial == true)
                return true;


            return false;
        }
    }
}
