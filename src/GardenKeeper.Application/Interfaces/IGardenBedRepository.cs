using GardenKeeper.Domain.Entities;

namespace GardenKeeper.Application.Interfaces;

public interface IGardenBedRepository
{
    Task<IEnumerable<GardenBed>> GetByUserAsync(string userId);
    Task<GardenBed?> GetByIdAsync(int id, bool includePlacements = false, bool includeLogs = false);
    Task<GardenBed> CreateAsync(GardenBed bed);
    Task UpdateAsync(GardenBed bed);
    Task DeleteAsync(int id);
    Task<PlantPlacement> AddPlacementAsync(PlantPlacement placement);
    Task RemovePlacementAsync(int placementId);
    Task<PlantPlacement?> GetPlacementAsync(int placementId);
}
