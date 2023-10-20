using BirzhaMaterialov.Domain;
using Microsoft.EntityFrameworkCore;

namespace BirzhaMaterialov.Application.Interfaces
{
    /// <summary>
    /// Db context interface. Used for DI and Dependency Inversion.
    /// </summary>
    public interface IApplicationDbContext
    {
        DbSet<Seller> Sellers { get; }

        DbSet<Material> Materials { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
