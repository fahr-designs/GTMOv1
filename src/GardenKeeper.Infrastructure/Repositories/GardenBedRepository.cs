using GardenKeeper.Application.Interfaces;
using GardenKeeper.Domain.Entities;
using GardenKeeper.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace GardenKeeper.Infrastructure.Repositories;

public class GardenBedRepository : IGardenBedRepository
{
    private readonly ApplicationDbContext _db;

    public GardenBedRepository(ApplicationDbContext db) => _db = db;

    public async Task<IEnumerable<GardenBed>> GetByUserAsync(string userId)
        => await _db.GardenBeds
            .Where(b => b.UserId == userId)
            .Include(b => b.PlantPlacements)
            .OrderByDescending(b => b.Season)
            .ThenBy(b => b.Name)
            .ToListAsync();

    public async Task<GardenBed?> GetByIdAsync(int id, bool includePlacements = false, bool includeLogs = false)
    {
        var query = _db.GardenBeds.AsQueryable();

        if (includePlacements)
            query = query.Include(b => b.PlantPlacements).ThenInclude(p => p.Plant);

        if (includeLogs)
            query = query.Include(b => b.LogEntries).ThenInclude(l => l.Plant);

        return await query.FirstOrDefaultAsync(b => b.Id == id);
    }

    public async Task<GardenBed> CreateAsync(GardenBed bed)
    {
        _db.GardenBeds.Add(bed);
        await _db.SaveChangesAsync();
        return bed;
    }

    public async Task UpdateAsync(GardenBed bed)
    {
        _db.GardenBeds.Update(bed);
        await _db.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var bed = await _db.GardenBeds.FindAsync(id);
        if (bed is not null)
        {
            _db.GardenBeds.Remove(bed);
            await _db.SaveChangesAsync();
        }
    }

    public async Task<PlantPlacement> AddPlacementAsync(PlantPlacement placement)
    {
        _db.PlantPlacements.Add(placement);
        await _db.SaveChangesAsync();
        return placement;
    }

    public async Task RemovePlacementAsync(int placementId)
    {
        var placement = await _db.PlantPlacements.FindAsync(placementId);
        if (placement is not null)
        {
            _db.PlantPlacements.Remove(placement);
            await _db.SaveChangesAsync();
        }
    }

    public async Task<PlantPlacement?> GetPlacementAsync(int placementId)
        => await _db.PlantPlacements.FindAsync(placementId);
}
