using GardenKeeper.Domain.Entities;

namespace GardenKeeper.Application.Interfaces;

public interface ILogEntryRepository
{
    Task<IEnumerable<LogEntry>> GetByUserAsync(string userId);
    Task<IEnumerable<LogEntry>> GetByBedAsync(int bedId);
    Task<IEnumerable<LogEntry>> GetByPlantAsync(int plantId, string userId);
    Task<IEnumerable<LogEntry>> GetRecentByUserAsync(string userId, int count);
    Task<LogEntry> CreateAsync(LogEntry entry);
    Task DeleteAsync(int id);
}
