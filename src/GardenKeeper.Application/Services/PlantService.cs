using GardenKeeper.Application.Interfaces;
using GardenKeeper.Application.ViewModels;
using GardenKeeper.Domain.Entities;
using GardenKeeper.Domain.Enums;

namespace GardenKeeper.Application.Services;

public class PlantService : IPlantService
{
    private readonly IPlantRepository _repository;

    public PlantService(IPlantRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Plant>> GetAllAsync()
        => await _repository.GetAllAsync();

    public async Task<PlantSearchViewModel> SearchAsync(string? searchTerm, PlantType? plantType, string? hardinessZone, SunRequirement? sunRequirement)
    {
        var results = await _repository.SearchAsync(searchTerm, plantType, hardinessZone, sunRequirement);
        return new PlantSearchViewModel
        {
            SearchTerm = searchTerm,
            PlantType = plantType,
            HardinessZone = hardinessZone,
            SunRequirement = sunRequirement,
            Results = results
        };
    }

    public async Task<PlantDetailViewModel?> GetDetailAsync(int id)
    {
        var plant = await _repository.GetByIdAsync(id);
        if (plant is null) return null;

        var companions = new List<Plant>();
        if (!string.IsNullOrWhiteSpace(plant.CompanionPlants))
        {
            var allPlants = await _repository.GetAllAsync();
            var names = plant.CompanionPlants.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
            companions = allPlants
                .Where(p => names.Any(n => p.CommonName.Contains(n, StringComparison.OrdinalIgnoreCase)))
                .ToList();
        }

        return new PlantDetailViewModel
        {
            Plant = plant,
            CompanionPlantObjects = companions
        };
    }
}
