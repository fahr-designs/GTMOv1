using FluentAssertions;
using GardenKeeper.Application.Interfaces;
using GardenKeeper.Application.Services;
using GardenKeeper.Domain.Entities;
using GardenKeeper.Domain.Enums;
using Moq;

namespace GardenKeeper.Tests;

public class PlantServiceTests
{
    private static IEnumerable<Plant> SamplePlants() =>
    [
        new Plant { Id = 1, CommonName = "Tomato",       ScientificName = "Solanum lycopersicum", PlantType = PlantType.Vegetable,   HardinessZones = "5b,6a,6b,7a", SunRequirement = SunRequirement.FullSun,      CompanionPlants = "Basil" },
        new Plant { Id = 2, CommonName = "Basil",        ScientificName = "Ocimum basilicum",     PlantType = PlantType.Herb,        HardinessZones = "6a,6b,7a",    SunRequirement = SunRequirement.FullSun,      CompanionPlants = "Tomato" },
        new Plant { Id = 3, CommonName = "Wild Bergamot",ScientificName = "Monarda fistulosa",    PlantType = PlantType.NativePlant, HardinessZones = "5b,6a,6b,7a", SunRequirement = SunRequirement.FullSun,      CompanionPlants = "Coneflower" },
        new Plant { Id = 4, CommonName = "Lettuce",      ScientificName = "Lactuca sativa",       PlantType = PlantType.Vegetable,   HardinessZones = "5b,6a,6b,7a", SunRequirement = SunRequirement.PartialShade, CompanionPlants = "Carrot" },
    ];

    [Fact]
    public async Task SearchAsync_NoFilters_ReturnsAllPlants()
    {
        var mockRepo = new Mock<IPlantRepository>();
        mockRepo.Setup(r => r.SearchAsync(null, null, null, null))
                .ReturnsAsync(SamplePlants());

        var service = new PlantService(mockRepo.Object);
        var result  = await service.SearchAsync(null, null, null, null);

        result.Results.Should().HaveCount(4);
    }

    [Fact]
    public async Task SearchAsync_FilterByPlantType_ReturnsMatchingPlants()
    {
        var vegetables = SamplePlants().Where(p => p.PlantType == PlantType.Vegetable);
        var mockRepo   = new Mock<IPlantRepository>();
        mockRepo.Setup(r => r.SearchAsync(null, PlantType.Vegetable, null, null))
                .ReturnsAsync(vegetables);

        var service = new PlantService(mockRepo.Object);
        var result  = await service.SearchAsync(null, PlantType.Vegetable, null, null);

        result.Results.Should().HaveCount(2);
        result.Results.Should().AllSatisfy(p => p.PlantType.Should().Be(PlantType.Vegetable));
        result.PlantType.Should().Be(PlantType.Vegetable);
    }

    [Fact]
    public async Task SearchAsync_FilterByZone_PreservesFilter()
    {
        var zone6b = SamplePlants().Where(p => p.HardinessZones.Contains("6b"));
        var mockRepo = new Mock<IPlantRepository>();
        mockRepo.Setup(r => r.SearchAsync(null, null, "6b", null)).ReturnsAsync(zone6b);

        var service = new PlantService(mockRepo.Object);
        var result  = await service.SearchAsync(null, null, "6b", null);

        result.HardinessZone.Should().Be("6b");
        result.Results.Should().OnlyContain(p => p.HardinessZones.Contains("6b"));
    }

    [Fact]
    public async Task GetDetailAsync_ValidId_ReturnsPlanWithDetail()
    {
        var tomato  = SamplePlants().First(p => p.Id == 1);
        var basil   = SamplePlants().First(p => p.Id == 2);
        var mockRepo = new Mock<IPlantRepository>();
        mockRepo.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(tomato);
        mockRepo.Setup(r => r.GetAllAsync()).ReturnsAsync(SamplePlants());

        var service = new PlantService(mockRepo.Object);
        var result  = await service.GetDetailAsync(1);

        result.Should().NotBeNull();
        result!.Plant.CommonName.Should().Be("Tomato");
        result.CompanionPlantObjects.Should().Contain(p => p.CommonName == "Basil");
    }

    [Fact]
    public async Task GetDetailAsync_InvalidId_ReturnsNull()
    {
        var mockRepo = new Mock<IPlantRepository>();
        mockRepo.Setup(r => r.GetByIdAsync(999)).ReturnsAsync((Plant?)null);

        var service = new PlantService(mockRepo.Object);
        var result  = await service.GetDetailAsync(999);

        result.Should().BeNull();
    }

    [Fact]
    public async Task SearchAsync_FilterBySun_ReturnsCorrectResults()
    {
        var partial = SamplePlants().Where(p => p.SunRequirement == SunRequirement.PartialShade);
        var mockRepo = new Mock<IPlantRepository>();
        mockRepo.Setup(r => r.SearchAsync(null, null, null, SunRequirement.PartialShade))
                .ReturnsAsync(partial);

        var service = new PlantService(mockRepo.Object);
        var result  = await service.SearchAsync(null, null, null, SunRequirement.PartialShade);

        result.Results.Should().HaveCount(1);
        result.Results.First().CommonName.Should().Be("Lettuce");
    }
}
