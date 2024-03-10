using LearnHub.Identity.Features.Login.Requests;
using LearnHub.Identity.IdentityService.Abstract;
using LearnHub.Identity.Model.En;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;


namespace LearnHub.Identity.Features.Login.Handlers
{
    public class Login_H : IRequestHandler<Login_R, string>
    {
        public static User_En user = new User_En();
        private readonly IConfiguration _configuration;
        private readonly Iuser _user;

        public Login_H(IConfiguration configuration, Iuser user)
        {
            _configuration = configuration;
            _user = user;
        }

        public async Task<string> Handle(Login_R request, CancellationToken cancellationToken)
        {
            var User = await _user.GetUserByEmail(request.login_Dto.Email);

            if (User == null)
            {
                return "User not found.";
            }

            if (!VerifyPasswordHash(request.login_Dto.Password, User.PasswordHash, User.PasswordSalt))
            {
                return "Wrong password.";
            }

            string token = CreateToken(User);


            return token;
        }

        private string CreateToken(User_En user)
        {
            var claims = new List<Claim>
    {
        new Claim(ClaimTypes.Name, user.Username) , 
        new Claim(ClaimTypes.Email , user.Email)
    };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["AppSettings:Token"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds
            );

            var tokenHandler = new JwtSecurityTokenHandler();
            var jwt = tokenHandler.WriteToken(token);



            return jwt;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }
    }
}
