using GardenKeeper.Application.Interfaces;
using GardenKeeper.Domain.Entities;
using GardenKeeper.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace GardenKeeper.Infrastructure.Repositories;

public class LogEntryRepository : ILogEntryRepository
{
    private readonly ApplicationDbContext _db;

    public LogEntryRepository(ApplicationDbContext db) => _db = db;

    public async Task<IEnumerable<LogEntry>> GetByUserAsync(string userId)
        => await _db.LogEntries
            .Where(l => l.UserId == userId)
            .Include(l => l.Plant)
            .Include(l => l.GardenBed)
            .OrderByDescending(l => l.EntryDate)
            .ToListAsync();

    public async Task<IEnumerable<LogEntry>> GetByBedAsync(int bedId)
        => await _db.LogEntries
            .Where(l => l.GardenBedId == bedId)
            .Include(l => l.Plant)
            .OrderByDescending(l => l.EntryDate)
            .ToListAsync();

    public async Task<IEnumerable<LogEntry>> GetByPlantAsync(int plantId, string userId)
        => await _db.LogEntries
            .Where(l => l.PlantId == plantId && l.UserId == userId)
            .Include(l => l.GardenBed)
            .OrderByDescending(l => l.EntryDate)
            .ToListAsync();

    public async Task<IEnumerable<LogEntry>> GetRecentByUserAsync(string userId, int count)
        => await _db.LogEntries
            .Where(l => l.UserId == userId)
            .Include(l => l.Plant)
            .Include(l => l.GardenBed)
            .OrderByDescending(l => l.EntryDate)
            .Take(count)
            .ToListAsync();

    public async Task<LogEntry> CreateAsync(LogEntry entry)
    {
        _db.LogEntries.Add(entry);
        await _db.SaveChangesAsync();
        return entry;
    }

    public async Task DeleteAsync(int id)
    {
        var entry = await _db.LogEntries.FindAsync(id);
        if (entry is not null)
        {
            _db.LogEntries.Remove(entry);
            await _db.SaveChangesAsync();
        }
    }
}
