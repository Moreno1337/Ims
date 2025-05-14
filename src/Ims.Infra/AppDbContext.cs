using Ims.Application.Interfaces;
using Ims.Domain.Customers;
using Ims.Domain.Shared.Interfaces;
using Ims.Infra.Customers;
using Microsoft.EntityFrameworkCore;

namespace Ims.Infra;

public class AppDbContext : DbContext
{
    private readonly ICurrentUser _currentUser;
    private readonly ICurrentTenant _currentTenant;
    public DbSet<Customer> Customers { get; set; }

    public AppDbContext(
        DbContextOptions<AppDbContext> options,
        ICurrentUser currentUser,
        ICurrentTenant currentTenant
    ) : base(options) 
    { 
        _currentUser = currentUser;
        _currentTenant = currentTenant;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CustomerConfiguration());
    }

    public override int SaveChanges()
    {
        ApplyAdditionalInfo();
        return base.SaveChanges();
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        ApplyAdditionalInfo();
        return base.SaveChangesAsync(cancellationToken);
    }

    private bool HasAuditFields(Type clrType)
    {
        return typeof(IAuditable).IsAssignableFrom(clrType);
    }

    private bool HasTenantField(Type clrType)
    {
        return typeof(IHasTenant).IsAssignableFrom(clrType);
    }

    private void ApplyAdditionalInfo()
    {
        var now = DateTime.UtcNow;
        var user = _currentUser.GetUserId();
        var tenantId = _currentTenant.GetTenantId();

        foreach (var entry in ChangeTracker.Entries())
        {
            var entityType = entry.Entity.GetType();

            if (HasTenantField(entityType))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("TenantId").CurrentValue = tenantId;
                }
            }

            if (HasAuditFields(entityType))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("CreatedBy").CurrentValue = user;
                    entry.Property("CreatedAt").CurrentValue = now;

                    entry.Property("Status").CurrentValue = true;
                }
                else if (entry.State == EntityState.Modified)
                {
                    entry.Property("UpdatedBy").CurrentValue = user;
                    entry.Property("UpdatedAt").CurrentValue = now;
                }
            }
        }
    }
}