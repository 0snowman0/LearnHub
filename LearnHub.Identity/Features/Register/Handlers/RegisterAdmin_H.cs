using AutoMapper;
using LearnHub.Application.Contracts.permistion;
using LearnHub.Application.Contracts.Profile;
using LearnHub.Application.Responses;
using LearnHub.Domain.Model.Permistion;
using LearnHub.Domain.Model.Prifile.Admin;
using LearnHub.Identity.Features.Register.Requests;
using LearnHub.Identity.IdentityService.Abstract;
using LearnHub.Identity.Model.En;
using MediatR;
using System.Security.Cryptography;

namespace LearnHub.Identity.Features.Register.Handlers
{
    public class RegisterAdmin_H : IRequestHandler<RegisterAdmin_R, BaseCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly Iuser _user;
        private readonly IPermistion _permission;
        private readonly IAdminProfile _adminProfile;
        public RegisterAdmin_H(IMapper mapper, Iuser user, IPermistion permission, IAdminProfile adminProfile)
        {
            _mapper = mapper;
            _user = user;
            _permission = permission;
            _adminProfile = adminProfile;
        }

        public async Task<BaseCommandResponse> Handle(RegisterAdmin_R request, CancellationToken cancellationToken)
        {
            var responce = new BaseCommandResponse();

            var user = new User_En();
            var Admin = new AdminProfile_En();

            #region Add User
            CreatePasswordHash(request.registerAdmin.Password, out byte[] passwordHash, out byte[] passwordSalt);

            user.Email = request.registerAdmin.Email;
            user.Username = request.registerAdmin.UserName;
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            user.role_Em = (LearnHub.Domain.Enum.Role_Em)request.registerAdmin.role_Em;

            #endregion

            await _user.Add(user);


            Admin.UserId = user.Id;
            
            var permistion = _mapper.Map<Permistion_En>(request.registerAdmin.permistion_Dtos);
            await _permission.Add(permistion);

            Admin.permistion_En = permistion;
            await _adminProfile.Add(Admin);

            responce.Success(Admin);
            return responce;
        }
        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}
