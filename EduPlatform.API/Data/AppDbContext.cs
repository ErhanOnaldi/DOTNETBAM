using EduPlatform.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace EduPlatform.API.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Course> Courses => Set<Course>();
    public DbSet<Category> Categories => Set<Category>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Bu assembly'deki tüm IEntityTypeConfiguration'ları otomatik uygula
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }

    public override async Task<int> SaveChangesAsync(
        CancellationToken cancellationToken = default)
    {
        foreach (var entry in ChangeTracker.Entries())
        {
            if (entry.State == EntityState.Added
                && entry.Metadata.FindProperty("CreatedAt") != null)  // ← var mı diye sor
                entry.Property("CreatedAt").CurrentValue = DateTime.UtcNow;

            if (entry.State == EntityState.Modified
                && entry.Metadata.FindProperty("UpdatedAt") != null)  // ← var mı diye sor
                entry.Property("UpdatedAt").CurrentValue = DateTime.UtcNow;
        }
        return await base.SaveChangesAsync(cancellationToken);
    }
}
