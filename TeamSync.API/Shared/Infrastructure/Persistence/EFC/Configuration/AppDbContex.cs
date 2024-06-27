using System.Collections.Immutable;
using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;
using TeamSync.API.IAM.Domain.Model.Aggregates;
using TeamSync.API.ManagerProject.Domain.Model.Aggregates;
using TeamSync.API.ManagerProject.Domain.Model.Entities;
using TeamSync.API.Profile.Domain.Model.Aggregates;
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
        builder.Entity<Comment>().HasKey(c => c.Id);
        builder.Entity<Comment>().Property(c => c.Id)
            .IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Comment>().Property(c => c.content)
            .HasMaxLength(100);
        builder.Entity<Comment>().Property(c => c.profileId);
            
        
        //=======================================================
        builder.Entity<Project>()
            .HasMany(p => p.Files)
            .WithOne(f => f.project)
            .HasForeignKey(f => f.ProjectId)
            .HasPrincipalKey(p => p.Id);

        builder.Entity<Project>()
            .HasMany(c => c.Comments)
            .WithOne(c => c.project)
            .HasForeignKey(c => c.ProjectId)
            .HasPrincipalKey(p => p.Id);
        
        //=======================================================
        builder.Entity<profile>().HasKey(p => p.Id);
        builder.Entity<profile>().Property(p => p.Id)
            .IsRequired().ValueGeneratedOnAdd();
        builder.Entity<profile>().Property(p => p.LastName)
            .HasMaxLength(100);
        builder.Entity<profile>().Property(p => p.Address)
            .HasMaxLength(100);
        builder.Entity<profile>().Property(p => p.Picture)
            .HasColumnType("LONGBLOB");
        builder.Entity<profile>().Property(p => p.FirstName)
            .HasMaxLength(100);
        builder.Entity<profile>().Property(p => p.RoleId)
            .HasMaxLength(100);
        builder.Entity<profile>().Property(p => p.EmailAddress)
            .HasMaxLength(100);
        builder.Entity<profile>().Property(p => p.Membership)
            .HasMaxLength(100);
        
        // IAM Context
        
        builder.Entity<User>().HasKey(u => u.Id);
        builder.Entity<User>().Property(u => u.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<User>().Property(u => u.Username).IsRequired();
        builder.Entity<User>().Property(u => u.PasswordHash).IsRequired();
        builder.Entity<User>().Property(u => u.ProfileId).IsRequired();
        //=======================================================
        builder.UseSnakeCaseWithPluralizedTableNamingConvention();
        
    }
}