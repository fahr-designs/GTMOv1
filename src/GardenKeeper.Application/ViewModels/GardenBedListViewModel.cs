using GardenKeeper.Domain.Entities;

namespace GardenKeeper.Application.ViewModels;

public class GardenBedListViewModel
{
    public IEnumerable<GardenBed> Beds { get; set; } = [];
}
