using System.ComponentModel.DataAnnotations;

namespace LearnHub.Identity.Model.En
{
    public class User_En
    {
        [Key]
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public  string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string RefreshToken { get; set; } = string.Empty;
        public DateTime TokenCreated { get; set; }
        public DateTime TokenExpires { get; set; }
    }
}
