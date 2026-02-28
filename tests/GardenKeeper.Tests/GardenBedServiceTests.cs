using FluentAssertions;
using GardenKeeper.Application.Interfaces;
using GardenKeeper.Application.Services;
using GardenKeeper.Application.ViewModels;
using GardenKeeper.Domain.Entities;
using Moq;

namespace GardenKeeper.Tests;

public class GardenBedServiceTests
{
    private const string UserId = "user-123";

    private static GardenBed MakeBed(int id = 1, string name = "Test Bed") => new GardenBed
    {
        Id = id, UserId = UserId, Name = name,
        WidthFeet = 4, LengthFeet = 8, Season = 2026,
        PlantPlacements = new List<PlantPlacement>()
    };

    [Fact]
    public async Task CreateBedAsync_ValidModel_ReturnsBedId()
    {
        var mockBed  = new Mock<IGardenBedRepository>();
        var mockPlant = new Mock<IPlantRepository>();
        var created  = MakeBed(42);
        mockBed.Setup(r => r.CreateAsync(It.IsAny<GardenBed>())).ReturnsAsync(created);

        var service = new GardenBedService(mockBed.Object, mockPlant.Object);
        var model   = new CreateBedViewModel { Name = "Test Bed", WidthFeet = 4, LengthFeet = 8 };
        var id      = await service.CreateBedAsync(model, UserId);

        id.Should().Be(42);
        mockBed.Verify(r => r.CreateAsync(It.Is<GardenBed>(b =>
            b.UserId == UserId &&
            b.Name   == "Test Bed" &&
            b.WidthFeet == 4 &&
            b.LengthFeet == 8)), Times.Once);
    }

    [Fact]
    public async Task GetBedDetailAsync_WrongUser_ReturnsNull()
    {
        var bed      = MakeBed();
        bed.UserId   = "other-user";
        var mockBed  = new Mock<IGardenBedRepository>();
        var mockPlant = new Mock<IPlantRepository>();
        mockBed.Setup(r => r.GetByIdAsync(1, true, true)).ReturnsAsync(bed);

        var service = new GardenBedService(mockBed.Object, mockPlant.Object);
        var result  = await service.GetBedDetailAsync(1, UserId);

        result.Should().BeNull();
    }

    [Fact]
    public async Task GetBedDetailAsync_CorrectUser_ReturnsBedDetail()
    {
        var bed      = MakeBed();
        bed.LogEntries = new List<LogEntry>();
        var mockBed  = new Mock<IGardenBedRepository>();
        var mockPlant = new Mock<IPlantRepository>();
        mockBed.Setup(r => r.GetByIdAsync(1, true, true)).ReturnsAsync(bed);

        var service = new GardenBedService(mockBed.Object, mockPlant.Object);
        var result  = await service.GetBedDetailAsync(1, UserId);

        result.Should().NotBeNull();
        result!.Bed.Name.Should().Be("Test Bed");
    }

    [Fact]
    public async Task AddPlacementAsync_OutOfBounds_ReturnsFalse()
    {
        var bed = MakeBed();
        var mockBed  = new Mock<IGardenBedRepository>();
        var mockPlant = new Mock<IPlantRepository>();
        mockBed.Setup(r => r.GetByIdAsync(1, true, false)).ReturnsAsync(bed);
        mockPlant.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(new Plant { Id = 1 });

        var service = new GardenBedService(mockBed.Object, mockPlant.Object);
        var model   = new PlantPlacementViewModel { BedId = 1, PlantId = 1, GridX = 10, GridY = 0 }; // out of 4-wide bed
        var result  = await service.AddPlacementAsync(model, UserId);

        result.Should().BeFalse();
    }

    [Fact]
    public async Task AddPlacementAsync_CellAlreadyOccupied_ReturnsFalse()
    {
        var bed = MakeBed();
        bed.PlantPlacements = new List<PlantPlacement>
        {
            new PlantPlacement { Id = 99, GridX = 1, GridY = 1, PlantId = 1, GardenBedId = 1 }
        };
        var mockBed  = new Mock<IGardenBedRepository>();
        var mockPlant = new Mock<IPlantRepository>();
        mockBed.Setup(r => r.GetByIdAsync(1, true, false)).ReturnsAsync(bed);
        mockPlant.Setup(r => r.GetByIdAsync(2)).ReturnsAsync(new Plant { Id = 2 });

        var service = new GardenBedService(mockBed.Object, mockPlant.Object);
        var model   = new PlantPlacementViewModel { BedId = 1, PlantId = 2, GridX = 1, GridY = 1 };
        var result  = await service.AddPlacementAsync(model, UserId);

        result.Should().BeFalse();
    }

    [Fact]
    public async Task DeleteBedAsync_OwnerUser_CallsDeleteOnce()
    {
        var bed     = MakeBed();
        var mockBed = new Mock<IGardenBedRepository>();
        var mockPlant = new Mock<IPlantRepository>();
        mockBed.Setup(r => r.GetByIdAsync(1, false, false)).ReturnsAsync(bed);

        var service = new GardenBedService(mockBed.Object, mockPlant.Object);
        await service.DeleteBedAsync(1, UserId);

        mockBed.Verify(r => r.DeleteAsync(1), Times.Once);
    }
}
