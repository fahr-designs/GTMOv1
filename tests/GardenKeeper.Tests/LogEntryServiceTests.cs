using FluentAssertions;
using GardenKeeper.Application.Interfaces;
using GardenKeeper.Application.Services;
using GardenKeeper.Application.ViewModels;
using GardenKeeper.Domain.Entities;
using GardenKeeper.Domain.Enums;
using Moq;

namespace GardenKeeper.Tests;

public class LogEntryServiceTests
{
    private const string UserId = "user-abc";

    private static GardenBed MakeBed(int id = 1) => new GardenBed
    {
        Id = id, UserId = UserId, Name = "Veggie Bed",
        WidthFeet = 4, LengthFeet = 8, Season = 2026,
        PlantPlacements = new List<PlantPlacement>()
    };

    private static LogEntry MakeEntry(int id = 1, int bedId = 1) => new LogEntry
    {
        Id = id, GardenBedId = bedId, UserId = UserId,
        EntryDate = DateTime.Today,
        EntryType = LogEntryType.Planting,
        Notes = "Test note",
        GardenBed = MakeBed(bedId)
    };

    [Fact]
    public async Task GetUserLogAsync_ReturnsAllUserEntries()
    {
        var entries = new[] { MakeEntry(1), MakeEntry(2) };
        var mockLog   = new Mock<ILogEntryRepository>();
        var mockBed   = new Mock<IGardenBedRepository>();
        var mockPlant = new Mock<IPlantRepository>();

        mockLog.Setup(r => r.GetByUserAsync(UserId)).ReturnsAsync(entries);
        mockBed.Setup(r => r.GetByIdAsync(It.IsAny<int>(), false, false))
               .ReturnsAsync(MakeBed());

        var service = new LogEntryService(mockLog.Object, mockBed.Object, mockPlant.Object);
        var result  = await service.GetUserLogAsync(UserId);

        result.Entries.Should().HaveCount(2);
    }

    [Fact]
    public async Task CreateEntryAsync_ValidBed_CallsRepository()
    {
        var bed     = MakeBed();
        var mockLog   = new Mock<ILogEntryRepository>();
        var mockBed   = new Mock<IGardenBedRepository>();
        var mockPlant = new Mock<IPlantRepository>();

        mockBed.Setup(r => r.GetByIdAsync(1, false, false)).ReturnsAsync(bed);
        mockLog.Setup(r => r.CreateAsync(It.IsAny<LogEntry>())).ReturnsAsync(MakeEntry());

        var service = new LogEntryService(mockLog.Object, mockBed.Object, mockPlant.Object);
        var model   = new LogEntryCreateViewModel
        {
            BedId     = 1,
            EntryDate = DateTime.Today,
            EntryType = LogEntryType.Observation,
            Notes     = "Noticed aphids on tomato"
        };

        await service.CreateEntryAsync(model, UserId);

        mockLog.Verify(r => r.CreateAsync(It.Is<LogEntry>(e =>
            e.UserId    == UserId &&
            e.GardenBedId == 1 &&
            e.Notes     == "Noticed aphids on tomato")), Times.Once);
    }

    [Fact]
    public async Task CreateEntryAsync_WrongUser_DoesNotCallRepository()
    {
        var bed     = MakeBed();
        bed.UserId  = "other-user";
        var mockLog   = new Mock<ILogEntryRepository>();
        var mockBed   = new Mock<IGardenBedRepository>();
        var mockPlant = new Mock<IPlantRepository>();

        mockBed.Setup(r => r.GetByIdAsync(1, false, false)).ReturnsAsync(bed);

        var service = new LogEntryService(mockLog.Object, mockBed.Object, mockPlant.Object);
        var model   = new LogEntryCreateViewModel { BedId = 1, EntryDate = DateTime.Today, EntryType = LogEntryType.Other, Notes = "x" };

        await service.CreateEntryAsync(model, UserId);

        mockLog.Verify(r => r.CreateAsync(It.IsAny<LogEntry>()), Times.Never);
    }

    [Fact]
    public async Task GetDashboardAsync_ReturnsCorrectSeason()
    {
        var mockLog   = new Mock<ILogEntryRepository>();
        var mockBed   = new Mock<IGardenBedRepository>();
        var mockPlant = new Mock<IPlantRepository>();

        mockLog.Setup(r => r.GetRecentByUserAsync(UserId, 5)).ReturnsAsync([]);
        mockBed.Setup(r => r.GetByUserAsync(UserId)).ReturnsAsync([]);

        var service = new LogEntryService(mockLog.Object, mockBed.Object, mockPlant.Object);
        var result  = await service.GetDashboardAsync(UserId);

        result.Season.Should().Be(DateTime.Now.Year);
        result.RecentEntries.Should().BeEmpty();
        result.BedSummaries.Should().BeEmpty();
    }

    [Fact]
    public async Task DeleteEntryAsync_EntryBelongsToUser_CallsDelete()
    {
        var entry   = MakeEntry(5);
        var mockLog   = new Mock<ILogEntryRepository>();
        var mockBed   = new Mock<IGardenBedRepository>();
        var mockPlant = new Mock<IPlantRepository>();

        mockLog.Setup(r => r.GetByUserAsync(UserId)).ReturnsAsync(new[] { entry });

        var service = new LogEntryService(mockLog.Object, mockBed.Object, mockPlant.Object);
        await service.DeleteEntryAsync(5, UserId);

        mockLog.Verify(r => r.DeleteAsync(5), Times.Once);
    }
}
