using Microsoft.AspNetCore.Identity;
using NI2_API.Domain.Entities.User;

namespace NI2_API.Domain.Entities.Identity
{
    public class AppUser : IdentityUser<string>
    {
        public ICollection<Character> Characters { get; } = new List<Character>(); // Each user can have many chars
    }
}
