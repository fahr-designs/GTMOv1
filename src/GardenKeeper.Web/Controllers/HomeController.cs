using System.Diagnostics;
using GardenKeeper.Application.Interfaces;
using GardenKeeper.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GardenKeeper.Web.Controllers;

[Authorize]
public class HomeController : Controller
{
    private readonly ILogEntryService _logEntryService;

    public HomeController(ILogEntryService logEntryService)
    {
        _logEntryService = logEntryService;
    }

    public async Task<IActionResult> Index()
    {
        var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value ?? string.Empty;
        var dashboard = await _logEntryService.GetDashboardAsync(userId);
        return View(dashboard);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
