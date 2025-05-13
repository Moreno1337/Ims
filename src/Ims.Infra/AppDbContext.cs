using Ims.Application.Interfaces;
using Ims.Domain.Customers;
using Ims.Domain.Interfaces;
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
        ApplyAuditInfo();
        return base.SaveChanges();
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        ApplyAuditInfo();
        return base.SaveChangesAsync(cancellationToken);
    }

    private bool ShouldHaveAuditFields(Type clrType)
    {
        return typeof(IAuditable).IsAssignableFrom(clrType);
    }

    private void ApplyAuditInfo()
    {
        var now = DateTime.UtcNow;
        var user = _currentUser.GetUserId();
        var tenantId = _currentTenant.GetTenantId();

        foreach (var entry in ChangeTracker.Entries())
        {
            var entityType = entry.Entity.GetType();

            if (!ShouldHaveAuditFields(entityType)) continue;

            if (entry.State == EntityState.Added)
            {
                entry.Property("TenantId").CurrentValue = tenantId;
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