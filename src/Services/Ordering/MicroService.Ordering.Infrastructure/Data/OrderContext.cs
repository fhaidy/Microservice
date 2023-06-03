using MicroService.Ordering.Domain.Common;
using MicroService.Ordering.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MicroService.Ordering.Infrastructure.Data;

public class OrderContext : DbContext
{
    public OrderContext(DbContextOptions<OrderContext> options) : base(options)
    {
    }

    public DbSet<Order> Orders { get; set; }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (var entry in ChangeTracker.Entries<EntityBase>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedDate = DateTime.Now;
                    entry.Entity.CreatedBy = "fhaidy";
                    break;
                case EntityState.Modified:
                    entry.Entity.LastModifiedDate = DateTime.Now;
                    entry.Entity.LastModifiedBy = "fhaidy";
                    break;
                case EntityState.Detached:
                case EntityState.Unchanged:
                case EntityState.Deleted:
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }
}