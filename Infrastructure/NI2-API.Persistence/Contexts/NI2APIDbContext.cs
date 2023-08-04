using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NI2_API.Domain.Entities.Common;
using NI2_API.Domain.Entities.Identity;
using NI2_API.Domain.Entities.User;
using System.Security.Cryptography.X509Certificates;

namespace NI2_API.Persistence.Contexts
{
    public class NI2APIDbContext : IdentityDbContext<AppUser, AppRole, string>
    {
        public NI2APIDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Character> Characters { get; set; }
        public DbSet<Inventory> Inventories { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<AppUser>()
                .HasMany(c => c.Characters)
                .WithOne(u => u.AppUser)
                .HasForeignKey(u => u.UserId);

            builder.Entity<Character>()
                .HasOne(i => i.Inventory)
                .WithOne(c => c.Character)
                .HasForeignKey<Inventory>(u => u.Id);
              

            base.OnModelCreating(builder);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var datas = ChangeTracker.Entries<BaseEntity>();

            foreach (var data in datas)
            {
                _ = data.State switch
                {
                    EntityState.Added => data.Entity.CreatedDate = DateTime.UtcNow,
                    EntityState.Modified => data.Entity.UpdatedDate = DateTime.UtcNow,
                    _ => DateTime.UtcNow
                };
            }
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
