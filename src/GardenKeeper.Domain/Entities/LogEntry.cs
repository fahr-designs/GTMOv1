using GardenKeeper.Domain.Enums;

namespace GardenKeeper.Domain.Entities;

public class LogEntry
{
    public int Id { get; set; }
    public int GardenBedId { get; set; }
    public int? PlantId { get; set; }
    public string UserId { get; set; } = string.Empty;
    public DateTime EntryDate { get; set; }
    public LogEntryType EntryType { get; set; }
    public StartMethod? StartMethod { get; set; }
    public DateTime? ExpectedHarvestDate { get; set; }
    public string Notes { get; set; } = string.Empty;
    public GardenBed GardenBed { get; set; } = null!;
    public Plant? Plant { get; set; }
}
