namespace GardenKeeper.Application.ViewModels;

public class PlantPlacementViewModel
{
    public int BedId { get; set; }
    public int PlantId { get; set; }
    public int GridX { get; set; }
    public int GridY { get; set; }
    public string? PlantName { get; set; }
    public string? PlantColor { get; set; }
}
