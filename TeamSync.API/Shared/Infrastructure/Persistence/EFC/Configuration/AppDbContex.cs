using System.Collections.Immutable;
using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;
using TeamSync.API.ManagerProject.Domain.Model.Aggregates;
using TeamSync.API.ManagerProject.Domain.Model.Entities;
using TeamSync.API.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;


namespace TeamSync.API.Shared.Infrastructure.Persistence.EFC.Configuration;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        builder.AddCreatedUpdatedInterceptor();
        base.OnConfiguring(builder);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        //=======================================================
        builder.Entity<Project>().HasKey(p => p.Id);
        builder.Entity<Project>().Property(p => p.Id)
            .IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Project>().Property(p => p.Name)
            .HasMaxLength(100);
        builder.Entity<Project>().Property(p => p.Picture)
            .HasColumnType("LONGBLOB");
        
        //=======================================================
        builder.Entity<FileAsset>().HasKey(f => f.Id);
        builder.Entity<FileAsset>().Property(f => f.Id)
            .IsRequired().ValueGeneratedOnAdd();
        builder.Entity<FileAsset>().Property(f => f.Name)
            .HasMaxLength(100);
        builder.Entity<FileAsset>().Property(f => f.Datafile)
            .HasColumnType("LONGBLOB");
        builder.Entity<FileAsset>().Property(f => f.Type)
            .HasMaxLength(70);
        
        
        //=======================================================
        builder.Entity<Project>()
            .HasMany(p => p.Files)
            .WithOne(f => f.project)
            .HasForeignKey(f => f.ProjectId)
            .HasPrincipalKey(p => p.Id);
        //=======================================================
        
        
        builder.UseSnakeCaseWithPluralizedTableNamingConvention();
        
    }
}