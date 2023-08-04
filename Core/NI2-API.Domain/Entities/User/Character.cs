using NI2_API.Domain.Entities.Common;
using NI2_API.Domain.Entities.Identity;

namespace NI2_API.Domain.Entities.User
{
    public class Character : BaseEntity
    {
        public string UserId { get; set; }
        public AppUser AppUser { get; set; } // Each char can have "1" user
        public Inventory Inventory { get; set; } // Each char can have "1" inventory
    }
}
