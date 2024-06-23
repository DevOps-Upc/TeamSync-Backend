using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;
using professionals_back_wa.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;

namespace professionals_back_wa.Shared.Infrastructure.Persistence.EFC.Configuration;
public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        base.OnConfiguring(builder);
        // Enable Audit Fields Interceptors
        builder.AddCreatedUpdatedInterceptor();
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        // Apply SnakeCase Naming Convention
        builder.UseSnakeCaseWithPluralizedTableNamingConvention();
    }
}