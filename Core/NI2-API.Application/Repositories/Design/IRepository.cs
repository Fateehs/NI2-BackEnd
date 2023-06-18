using Microsoft.EntityFrameworkCore;
using NI2_API.Domain.Entities.Common;

namespace NI2_API.Application.Repositories.Design
{
    public interface IRepository<T> where T : BaseEntity
    {
        DbSet<T> Table { get; }
    }
}
