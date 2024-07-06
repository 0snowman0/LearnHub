using LearnHub.Application.Responses;
using LearnHub.Domain.Enum;
using LearnHub.Identity.Enum;
using LearnHub.Identity.Features.Register.Requests;
using LearnHub.Identity.IdentityService.Abstract;
using LearnHub.Identity.Model.En;
using MediatR;
using Microsoft.Extensions.Configuration;
using System.Security.Cryptography;

namespace LearnHub.Identity.Features.Register.Handlers
{
    public class Register_H : IRequestHandler<Register_R, BaseCommandResponse>
    {
        public static User_En user = new User_En();
        private readonly IConfiguration _configuration;
        private readonly Iuser _user;
        public Register_H(IConfiguration configuration, Iuser user)
        {
            _configuration = configuration;
            _user = user;
        }

        public async Task<BaseCommandResponse> Handle(Register_R request, CancellationToken cancellationToken)
        {
            var responce = new BaseCommandResponse();


            CreatePasswordHash(request.register_Dto.Password, out byte[] passwordHash, out byte[] passwordSalt);


            user.Email = request.register_Dto.Email;
            user.Username = request.register_Dto.UserName;
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            user.role_Em = (LearnHub.Domain.Enum.Role_Em)request.register_Dto.role;
            user.IsReport = false;
            user.Gender_Em = (Gender_Em)request.register_Dto.gender_Em;

            await _user.Add(user);
            await _user.SaveAsync();
            responce.Success(user);
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
