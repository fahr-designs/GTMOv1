namespace GardenKeeper.Domain.Entities;

public class GardenBed
{
    public int Id { get; set; }
    public string UserId { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public int WidthFeet { get; set; }
    public int LengthFeet { get; set; }
    public int Season { get; set; } // Year
    public ICollection<PlantPlacement> PlantPlacements { get; set; } = new List<PlantPlacement>();
    public ICollection<LogEntry> LogEntries { get; set; } = new List<LogEntry>();
}
