using NI2_API.Domain.Entities.Common;

namespace NI2_API.Domain.Entities.User
{
    public class Inventory : BaseEntity
    {
        public string CharacterId { get; set; }
        public Character Character { get; set; } // Each Inventory can have "1" character
    }
}
