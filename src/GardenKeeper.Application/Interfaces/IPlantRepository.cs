using GardenKeeper.Domain.Entities;
using GardenKeeper.Domain.Enums;

namespace GardenKeeper.Application.Interfaces;

public interface IPlantRepository
{
    Task<IEnumerable<Plant>> GetAllAsync();
    Task<Plant?> GetByIdAsync(int id);
    Task<IEnumerable<Plant>> SearchAsync(string? searchTerm, PlantType? plantType, string? hardinessZone, SunRequirement? sunRequirement);
}
