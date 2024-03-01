using LearnHub.Identity.Features.Register.Requests;
using LearnHub.Identity.IdentityService.Abstract;
using LearnHub.Identity.Model.En;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LearnHub.Identity.Features.Register.Handlers
{
    public class Register_H : IRequestHandler<Register_R, User_En>
    {
        public static User_En user = new User_En();
        private readonly IConfiguration _configuration;
        private readonly Iuser _user;
        public Register_H(IConfiguration configuration, Iuser user)
        {
            _configuration = configuration;
            _user = user;
        }

        public async Task<User_En> Handle(Register_R request, CancellationToken cancellationToken)
        {
            CreatePasswordHash(request.register_Dto.Password, out byte[] passwordHash, out byte[] passwordSalt);

            user.Email = request.register_Dto.Email;
            user.Username = request.register_Dto.UserName;
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            await _user.Add(user);

            return user;
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
