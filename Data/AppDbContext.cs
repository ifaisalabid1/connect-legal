using ConnectLegal.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ConnectLegal.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : IdentityDbContext<User>(options)
{
    public DbSet<LawFirm> LawFirms => Set<LawFirm>();
    public DbSet<Lawyer> Lawyers => Set<Lawyer>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<LawFirm>(e =>
        {
            e.HasKey(e => e.Id);
            e.Property(e => e.Name).IsRequired().HasMaxLength(255);
            e.Property(e => e.About).IsRequired().HasMaxLength(500);
            e.Property(e => e.Website).HasMaxLength(255);
            e.Property(e => e.Email).IsRequired().HasMaxLength(255);
            e.Property(e => e.IsFeatured).HasDefaultValue(false);
            e.HasIndex(e => e.Name);
            e.HasIndex(e => e.IsFeatured);
        });

        modelBuilder.Entity<Lawyer>(e =>
        {
            e.HasKey(e => e.Id);
            e.Property(e => e.Name).IsRequired().HasMaxLength(255);
            e.Property(e => e.About).IsRequired().HasMaxLength(500);
            e.Property(e => e.Website).HasMaxLength(255);
            e.Property(e => e.Email).IsRequired().HasMaxLength(255);
            e.Property(e => e.IsFeatured).HasDefaultValue(false);
            e.HasIndex(e => e.Name);
            e.HasIndex(e => e.IsFeatured);

            e.HasOne(l => l.LawFirm)
             .WithMany(f => f.Lawyers)
             .HasForeignKey(l => l.LawFirmId)
             .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<User>(e =>
        {
            e.Property(u => u.FirstName).IsRequired().HasMaxLength(255);
            e.Property(u => u.LastName).IsRequired().HasMaxLength(255);
            e.Property(u => u.CreatedAt).IsRequired();
        });
    }
}