using GardenKeeper.Application.ViewModels;

namespace GardenKeeper.Application.Interfaces;

public interface IGardenBedService
{
    Task<GardenBedListViewModel> GetUserBedsAsync(string userId);
    Task<GardenBedDetailViewModel?> GetBedDetailAsync(int bedId, string userId);
    Task<int> CreateBedAsync(CreateBedViewModel model, string userId);
    Task DeleteBedAsync(int bedId, string userId);
    Task<bool> AddPlacementAsync(PlantPlacementViewModel model, string userId);
    Task<bool> RemovePlacementAsync(int placementId, string userId);
    Task<IEnumerable<PlantPlacementViewModel>> GetGuidedLayoutAsync(int bedId, string goal, string userId);
}
