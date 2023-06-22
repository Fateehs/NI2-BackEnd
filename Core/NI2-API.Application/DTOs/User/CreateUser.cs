using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace NI2_API.Application.DTOs.User
{
    public class CreateUser
    {
        public string Username { get; set; }
        public string SteamId { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
