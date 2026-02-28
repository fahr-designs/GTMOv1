using GardenKeeper.Application.Interfaces;
using GardenKeeper.Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GardenKeeper.Web.Controllers;

[Authorize]
public class LogController : Controller
{
    private readonly ILogEntryService _logService;
    private readonly IGardenBedService _bedService;
    private readonly IPlantService _plantService;

    public LogController(ILogEntryService logService, IGardenBedService bedService, IPlantService plantService)
    {
        _logService = logService;
        _bedService = bedService;
        _plantService = plantService;
    }

    private string UserId => User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value ?? string.Empty;

    public async Task<IActionResult> Index()
    {
        var vm = await _logService.GetUserLogAsync(UserId);
        return View(vm);
    }

    [HttpGet]
    public async Task<IActionResult> Create(int? bedId)
    {
        var beds = await _bedService.GetUserBedsAsync(UserId);
        ViewBag.Beds = beds.Beds;
        ViewBag.Plants = await _plantService.GetAllAsync();

        var model = new LogEntryCreateViewModel
        {
            BedId = bedId ?? 0,
            EntryDate = DateTime.Today
        };
        return View(model);
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(LogEntryCreateViewModel model)
    {
        if (!ModelState.IsValid)
        {
            var beds = await _bedService.GetUserBedsAsync(UserId);
            ViewBag.Beds = beds.Beds;
            ViewBag.Plants = await _plantService.GetAllAsync();
            return View(model);
        }

        await _logService.CreateEntryAsync(model, UserId);
        return RedirectToAction(nameof(Index));
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int id)
    {
        await _logService.DeleteEntryAsync(id, UserId);
        return RedirectToAction(nameof(Index));
    }
}
