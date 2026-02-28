using GardenKeeper.Domain.Entities;

namespace GardenKeeper.Application.ViewModels;

public class BedSummary
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int WidthFeet { get; set; }
    public int LengthFeet { get; set; }
    public int PlantCount { get; set; }
    public int Season { get; set; }
}

public class DashboardViewModel
{
    public int Season { get; set; }
    public IEnumerable<LogEntryViewModel> RecentEntries { get; set; } = [];
    public IEnumerable<BedSummary> BedSummaries { get; set; } = [];
}
