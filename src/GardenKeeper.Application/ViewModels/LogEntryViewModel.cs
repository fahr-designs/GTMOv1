using GardenKeeper.Domain.Entities;

namespace GardenKeeper.Application.ViewModels;

public class LogEntryViewModel
{
    public LogEntry Entry { get; set; } = null!;
    public string BedName { get; set; } = string.Empty;
    public string? PlantName { get; set; }
}
