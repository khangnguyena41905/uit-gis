using Microsoft.EntityFrameworkCore;

namespace GIS.API.Abstractions;

public sealed class ApplicationDbContext: DbContext
{
    public ApplicationDbContext(
        DbContextOptions<ApplicationDbContext> options) 
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
        => builder.ApplyConfigurationsFromAssembly(AssemblyReference.Assembly);
}