using GardenKeeper.Application.Interfaces;
using GardenKeeper.Domain.Entities;
using GardenKeeper.Domain.Enums;
using GardenKeeper.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace GardenKeeper.Infrastructure.Repositories;

public class PlantRepository : IPlantRepository
{
    private readonly ApplicationDbContext _db;

    public PlantRepository(ApplicationDbContext db) => _db = db;

    public async Task<IEnumerable<Plant>> GetAllAsync()
        => await _db.Plants.OrderBy(p => p.CommonName).ToListAsync();

    public async Task<Plant?> GetByIdAsync(int id)
        => await _db.Plants.FindAsync(id);

    public async Task<IEnumerable<Plant>> SearchAsync(string? searchTerm, PlantType? plantType, string? hardinessZone, SunRequirement? sunRequirement)
    {
        var query = _db.Plants.AsQueryable();

        if (!string.IsNullOrWhiteSpace(searchTerm))
            query = query.Where(p =>
                p.CommonName.Contains(searchTerm) ||
                p.ScientificName.Contains(searchTerm));

        if (plantType.HasValue)
            query = query.Where(p => p.PlantType == plantType.Value);

        if (!string.IsNullOrWhiteSpace(hardinessZone))
            query = query.Where(p => p.HardinessZones.Contains(hardinessZone));

        if (sunRequirement.HasValue)
            query = query.Where(p => p.SunRequirement == sunRequirement.Value);

        return await query.OrderBy(p => p.CommonName).ToListAsync();
    }
}
