using GardenKeeper.Domain.Entities;

namespace GardenKeeper.Application.ViewModels;

public class LogHistoryViewModel
{
    public IEnumerable<LogEntryViewModel> Entries { get; set; } = [];
    public int? FilterBedId { get; set; }
    public int? FilterPlantId { get; set; }
}
