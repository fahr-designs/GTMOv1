using GardenKeeper.Application.ViewModels;
using GardenKeeper.Domain.Entities;
using GardenKeeper.Domain.Enums;

namespace GardenKeeper.Application.Interfaces;

public interface IPlantService
{
    Task<PlantSearchViewModel> SearchAsync(string? searchTerm, PlantType? plantType, string? hardinessZone, SunRequirement? sunRequirement);
    Task<PlantDetailViewModel?> GetDetailAsync(int id);
    Task<IEnumerable<Plant>> GetAllAsync();
}
