using GardenKeeper.Application.Interfaces;
using GardenKeeper.Application.ViewModels;
using GardenKeeper.Domain.Entities;

namespace GardenKeeper.Application.Services;

public class LogEntryService : ILogEntryService
{
    private readonly ILogEntryRepository _logRepository;
    private readonly IGardenBedRepository _bedRepository;
    private readonly IPlantRepository _plantRepository;

    public LogEntryService(ILogEntryRepository logRepository, IGardenBedRepository bedRepository, IPlantRepository plantRepository)
    {
        _logRepository = logRepository;
        _bedRepository = bedRepository;
        _plantRepository = plantRepository;
    }

    public async Task<LogHistoryViewModel> GetUserLogAsync(string userId)
    {
        var entries = await _logRepository.GetByUserAsync(userId);
        var viewModels = await MapToViewModelsAsync(entries);
        return new LogHistoryViewModel { Entries = viewModels };
    }

    public async Task<IEnumerable<LogEntryViewModel>> GetBedLogAsync(int bedId)
    {
        var entries = await _logRepository.GetByBedAsync(bedId);
        return await MapToViewModelsAsync(entries);
    }

    public async Task CreateEntryAsync(LogEntryCreateViewModel model, string userId)
    {
        var bed = await _bedRepository.GetByIdAsync(model.BedId);
        if (bed is null || bed.UserId != userId) return;

        var entry = new LogEntry
        {
            GardenBedId = model.BedId,
            PlantId = model.PlantId,
            UserId = userId,
            EntryDate = model.EntryDate,
            EntryType = model.EntryType,
            StartMethod = model.StartMethod,
            ExpectedHarvestDate = model.ExpectedHarvestDate,
            Notes = model.Notes
        };

        await _logRepository.CreateAsync(entry);
    }

    public async Task DeleteEntryAsync(int id, string userId)
    {
        var entries = await _logRepository.GetByUserAsync(userId);
        if (entries.Any(e => e.Id == id))
            await _logRepository.DeleteAsync(id);
    }

    public async Task<DashboardViewModel> GetDashboardAsync(string userId)
    {
        var recent = await _logRepository.GetRecentByUserAsync(userId, 5);
        var beds = await _bedRepository.GetByUserAsync(userId);

        var recentViewModels = await MapToViewModelsAsync(recent);
        var bedSummaries = beds.Select(b => new BedSummary
        {
            Id = b.Id,
            Name = b.Name,
            WidthFeet = b.WidthFeet,
            LengthFeet = b.LengthFeet,
            PlantCount = b.PlantPlacements?.Count ?? 0,
            Season = b.Season
        });

        return new DashboardViewModel
        {
            Season = DateTime.Now.Year,
            RecentEntries = recentViewModels,
            BedSummaries = bedSummaries
        };
    }

    private async Task<IEnumerable<LogEntryViewModel>> MapToViewModelsAsync(IEnumerable<LogEntry> entries)
    {
        var result = new List<LogEntryViewModel>();
        foreach (var entry in entries)
        {
            var bed = await _bedRepository.GetByIdAsync(entry.GardenBedId);
            Plant? plant = null;
            if (entry.PlantId.HasValue)
                plant = await _plantRepository.GetByIdAsync(entry.PlantId.Value);

            result.Add(new LogEntryViewModel
            {
                Entry = entry,
                BedName = bed?.Name ?? "Unknown",
                PlantName = plant?.CommonName
            });
        }
        return result;
    }
}
