using GardenKeeper.Application.Interfaces;
using GardenKeeper.Domain.Enums;
using Microsoft.AspNetCore.Mvc;

namespace GardenKeeper.Web.Controllers;

public class PlantsController : Controller
{
    private readonly IPlantService _plantService;

    public PlantsController(IPlantService plantService)
    {
        _plantService = plantService;
    }

    public async Task<IActionResult> Index(string? search, PlantType? type, string? zone, SunRequirement? sun)
    {
        var vm = await _plantService.SearchAsync(search, type, zone, sun);
        return View(vm);
    }

    public async Task<IActionResult> Detail(int id)
    {
        var vm = await _plantService.GetDetailAsync(id);
        if (vm is null) return NotFound();
        return View(vm);
    }
}
