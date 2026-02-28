using GardenKeeper.Application.Interfaces;
using GardenKeeper.Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GardenKeeper.Web.Controllers;

[Authorize]
public class BedsController : Controller
{
    private readonly IGardenBedService _bedService;
    private readonly IPlantService _plantService;

    public BedsController(IGardenBedService bedService, IPlantService plantService)
    {
        _bedService = bedService;
        _plantService = plantService;
    }

    private string UserId => User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value ?? string.Empty;

    public async Task<IActionResult> Index()
    {
        var vm = await _bedService.GetUserBedsAsync(UserId);
        return View(vm);
    }

    public async Task<IActionResult> Detail(int id)
    {
        var vm = await _bedService.GetBedDetailAsync(id, UserId);
        if (vm is null) return NotFound();

        ViewBag.AllPlants = await _plantService.GetAllAsync();
        return View(vm);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View(new CreateBedViewModel());
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CreateBedViewModel model)
    {
        if (!ModelState.IsValid) return View(model);
        var bedId = await _bedService.CreateBedAsync(model, UserId);
        return RedirectToAction(nameof(Detail), new { id = bedId });
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int id)
    {
        await _bedService.DeleteBedAsync(id, UserId);
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public async Task<IActionResult> AddPlacement([FromBody] PlantPlacementViewModel model)
    {
        var success = await _bedService.AddPlacementAsync(model, UserId);
        return success ? Ok() : BadRequest("Unable to place plant at that location.");
    }

    [HttpPost]
    public async Task<IActionResult> RemovePlacement([FromBody] int placementId)
    {
        var success = await _bedService.RemovePlacementAsync(placementId, UserId);
        return success ? Ok() : BadRequest();
    }

    [HttpGet]
    public async Task<IActionResult> GetGuidedLayout(int bedId, string goal)
    {
        var layout = await _bedService.GetGuidedLayoutAsync(bedId, goal, UserId);
        return Json(layout);
    }
}
