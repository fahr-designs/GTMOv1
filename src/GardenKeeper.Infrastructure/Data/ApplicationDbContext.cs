using GardenKeeper.Domain.Entities;
using GardenKeeper.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GardenKeeper.Infrastructure.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Plant> Plants => Set<Plant>();
    public DbSet<GardenBed> GardenBeds => Set<GardenBed>();
    public DbSet<PlantPlacement> PlantPlacements => Set<PlantPlacement>();
    public DbSet<LogEntry> LogEntries => Set<LogEntry>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<GardenBed>(e =>
        {
            e.HasIndex(b => b.UserId);
            e.HasMany(b => b.PlantPlacements)
             .WithOne(p => p.GardenBed)
             .HasForeignKey(p => p.GardenBedId)
             .OnDelete(DeleteBehavior.Cascade);
            e.HasMany(b => b.LogEntries)
             .WithOne(l => l.GardenBed)
             .HasForeignKey(l => l.GardenBedId)
             .OnDelete(DeleteBehavior.Cascade);
        });

        builder.Entity<LogEntry>(e =>
        {
            e.HasIndex(l => l.UserId);
            e.HasOne(l => l.Plant)
             .WithMany()
             .HasForeignKey(l => l.PlantId)
             .OnDelete(DeleteBehavior.SetNull);
        });

        builder.Entity<PlantPlacement>(e =>
        {
            e.HasOne(p => p.Plant)
             .WithMany()
             .HasForeignKey(p => p.PlantId)
             .OnDelete(DeleteBehavior.Restrict);
        });

        builder.Entity<Plant>().HasData(PlantSeedData.GetPlants());
    }
}
