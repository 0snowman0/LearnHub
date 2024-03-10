using LearnHub.Domain.Enum;
using System.ComponentModel.DataAnnotations;

namespace LearnHub.Identity.Model.En
{
    public class User_En
    {
        [Key]
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public  string Email { get; set; } = string.Empty ;
        public byte[] PasswordHash { get; set; } = null!;
        public byte[] PasswordSalt { get; set; } = null!;
        public string RefreshToken { get; set; } = string.Empty;
        public DateTime TokenCreated { get; set; }
        public DateTime TokenExpires { get; set; }
        public  bool IsReport { get; set; }
        public  Role_Em role_Em { get; set; }
    }
}
