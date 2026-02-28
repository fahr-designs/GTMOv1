namespace GardenKeeper.Domain.Entities;

public class PlantPlacement
{
    public int Id { get; set; }
    public int GardenBedId { get; set; }
    public int PlantId { get; set; }
    public int GridX { get; set; }
    public int GridY { get; set; }
    public Plant Plant { get; set; } = null!;
    public GardenBed GardenBed { get; set; } = null!;
}
