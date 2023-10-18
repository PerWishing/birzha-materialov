using BirzhaMaterialov.Domain;
using Microsoft.EntityFrameworkCore;

namespace BirzhaMaterialov.Application.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Seller> Sellers { get; }

        DbSet<Material> Materials { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
