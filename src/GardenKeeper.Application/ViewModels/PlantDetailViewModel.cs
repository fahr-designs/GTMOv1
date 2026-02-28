using GardenKeeper.Domain.Entities;

namespace GardenKeeper.Application.ViewModels;

public class PlantDetailViewModel
{
    public Plant Plant { get; set; } = null!;
    public IEnumerable<Plant> CompanionPlantObjects { get; set; } = [];
}
