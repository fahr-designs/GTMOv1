using GardenKeeper.Application.ViewModels;

namespace GardenKeeper.Application.Interfaces;

public interface ILogEntryService
{
    Task<LogHistoryViewModel> GetUserLogAsync(string userId);
    Task<IEnumerable<LogEntryViewModel>> GetBedLogAsync(int bedId);
    Task CreateEntryAsync(LogEntryCreateViewModel model, string userId);
    Task DeleteEntryAsync(int id, string userId);
    Task<DashboardViewModel> GetDashboardAsync(string userId);
}
