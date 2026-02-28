using GardenKeeper.Domain.Entities;

namespace GardenKeeper.Application.ViewModels;

public class GardenBedDetailViewModel
{
    public GardenBed Bed { get; set; } = null!;
    public IEnumerable<PlantPlacement> PlantPlacements { get; set; } = [];
    public IEnumerable<LogEntry> LogEntries { get; set; } = [];
}
