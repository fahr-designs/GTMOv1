using GardenKeeper.Domain.Entities;
using GardenKeeper.Domain.Enums;

namespace GardenKeeper.Application.ViewModels;

public class PlantSearchViewModel
{
    public string? SearchTerm { get; set; }
    public PlantType? PlantType { get; set; }
    public string? HardinessZone { get; set; }
    public SunRequirement? SunRequirement { get; set; }
    public IEnumerable<Plant> Results { get; set; } = [];
}
