using GardenKeeper.Domain.Enums;

namespace GardenKeeper.Domain.Entities;

public class Plant
{
    public int Id { get; set; }
    public string CommonName { get; set; } = string.Empty;
    public string ScientificName { get; set; } = string.Empty;
    public PlantType PlantType { get; set; }
    public string HardinessZones { get; set; } = string.Empty; // e.g. "5b,6a,6b,7a"
    public int DaysToMaturity { get; set; }
    public double SpacingInches { get; set; }
    public SunRequirement SunRequirement { get; set; }
    public WaterRequirement WaterRequirement { get; set; }
    public string CompanionPlants { get; set; } = string.Empty;
    public string CropRotationNotes { get; set; } = string.Empty;
    public StartMethod TypicalStartMethod { get; set; }
    public string DataSource { get; set; } = string.Empty;
    public string? Notes { get; set; }
}
