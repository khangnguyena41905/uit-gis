using GIS.API.Commons.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace GIS.API.Abstractions;

public sealed class ApplicationDbContext : DbContext
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public ApplicationDbContext(
        DbContextOptions<ApplicationDbContext> options,
        IHttpContextAccessor httpContextAccessor
        )
        : base(options)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    protected override void OnModelCreating(ModelBuilder builder)
        => builder.ApplyConfigurationsFromAssembly(AssemblyReference.Assembly);

    public override async Task<int> SaveChangesAsync(
        CancellationToken cancellationToken = default)
    {
        var username = _httpContextAccessor
            .HttpContext?.User?.Identity?.Name ?? "SYSTEM";
        //var now = DateTime.UtcNow;
        var now = DateTime.Now;

        foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
        {
            if (entry.State == EntityState.Added)
            {
                entry.Entity.CreatedAt = now;
                entry.Entity.CreatedBy = username;
            }

            if (entry.State == EntityState.Modified)
            {
                entry.Entity.UpdatedAt = now;
                entry.Entity.UpdatedBy = username;
            }
        }

        return await base.SaveChangesAsync(cancellationToken);
    }
}