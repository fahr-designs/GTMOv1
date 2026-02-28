using GardenKeeper.Application.Interfaces;
using GardenKeeper.Application.ViewModels;
using GardenKeeper.Domain.Entities;
using GardenKeeper.Domain.Enums;

namespace GardenKeeper.Application.Services;

public class GardenBedService : IGardenBedService
{
    private readonly IGardenBedRepository _bedRepository;
    private readonly IPlantRepository _plantRepository;

    public GardenBedService(IGardenBedRepository bedRepository, IPlantRepository plantRepository)
    {
        _bedRepository = bedRepository;
        _plantRepository = plantRepository;
    }

    public async Task<GardenBedListViewModel> GetUserBedsAsync(string userId)
    {
        var beds = await _bedRepository.GetByUserAsync(userId);
        return new GardenBedListViewModel { Beds = beds };
    }

    public async Task<GardenBedDetailViewModel?> GetBedDetailAsync(int bedId, string userId)
    {
        var bed = await _bedRepository.GetByIdAsync(bedId, includePlacements: true, includeLogs: true);
        if (bed is null || bed.UserId != userId) return null;

        return new GardenBedDetailViewModel
        {
            Bed = bed,
            PlantPlacements = bed.PlantPlacements,
            LogEntries = bed.LogEntries.OrderByDescending(l => l.EntryDate)
        };
    }

    public async Task<int> CreateBedAsync(CreateBedViewModel model, string userId)
    {
        var bed = new GardenBed
        {
            UserId = userId,
            Name = model.Name,
            WidthFeet = model.WidthFeet,
            LengthFeet = model.LengthFeet,
            Season = DateTime.Now.Year
        };
        var created = await _bedRepository.CreateAsync(bed);
        return created.Id;
    }

    public async Task DeleteBedAsync(int bedId, string userId)
    {
        var bed = await _bedRepository.GetByIdAsync(bedId);
        if (bed?.UserId == userId)
            await _bedRepository.DeleteAsync(bedId);
    }

    public async Task<bool> AddPlacementAsync(PlantPlacementViewModel model, string userId)
    {
        var bed = await _bedRepository.GetByIdAsync(model.BedId, includePlacements: true);
        if (bed is null || bed.UserId != userId) return false;

        var plant = await _plantRepository.GetByIdAsync(model.PlantId);
        if (plant is null) return false;

        // Validate coordinates are within bed bounds
        if (model.GridX < 0 || model.GridX >= bed.WidthFeet) return false;
        if (model.GridY < 0 || model.GridY >= bed.LengthFeet) return false;

        // Check for existing placement at that cell
        if (bed.PlantPlacements.Any(p => p.GridX == model.GridX && p.GridY == model.GridY))
            return false;

        var placement = new PlantPlacement
        {
            GardenBedId = model.BedId,
            PlantId = model.PlantId,
            GridX = model.GridX,
            GridY = model.GridY
        };

        await _bedRepository.AddPlacementAsync(placement);
        return true;
    }

    public async Task<bool> RemovePlacementAsync(int placementId, string userId)
    {
        var placement = await _bedRepository.GetPlacementAsync(placementId);
        if (placement is null) return false;

        var bed = await _bedRepository.GetByIdAsync(placement.GardenBedId);
        if (bed?.UserId != userId) return false;

        await _bedRepository.RemovePlacementAsync(placementId);
        return true;
    }

    public async Task<IEnumerable<PlantPlacementViewModel>> GetGuidedLayoutAsync(int bedId, string goal, string userId)
    {
        var bed = await _bedRepository.GetByIdAsync(bedId);
        if (bed is null || bed.UserId != userId) return [];

        var allPlants = await _plantRepository.GetAllAsync();
        var suggestions = new List<PlantPlacementViewModel>();

        IEnumerable<Plant> selected = goal.ToLowerInvariant() switch
        {
            "pollinator" => allPlants.Where(p =>
                p.PlantType == PlantType.NativePlant ||
                p.PlantType == PlantType.Flower ||
                (p.PlantType == PlantType.Herb && new[] { "Lavender", "Thyme", "Oregano", "Sage" }.Contains(p.CommonName))),
            "wildlife" => allPlants.Where(p =>
                p.PlantType == PlantType.NativePlant ||
                p.CommonName is "Plains Sunflower" or "Blackberry" or "Purple Coneflower"),
            _ => allPlants.Take(bed.WidthFeet * bed.LengthFeet)
        };

        var plants = selected.ToList();
        var idx = 0;
        for (var y = 0; y < bed.LengthFeet && idx < plants.Count; y++)
        {
            for (var x = 0; x < bed.WidthFeet && idx < plants.Count; x++, idx++)
            {
                suggestions.Add(new PlantPlacementViewModel
                {
                    BedId = bedId,
                    PlantId = plants[idx].Id,
                    GridX = x,
                    GridY = y,
                    PlantName = plants[idx].CommonName
                });
            }
        }

        return suggestions;
    }
}
