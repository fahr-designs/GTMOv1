using GardenKeeper.Infrastructure.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GardenKeeper.Web.Controllers;

[Authorize]
public class AccountController : Controller
{
    private readonly UserManager<ApplicationUser> _userManager;

    public AccountController(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    [HttpGet]
    public async Task<IActionResult> Settings()
    {
        var user = await _userManager.GetUserAsync(User);
        ViewBag.CurrentZone = user?.HardinessZone;
        return View();
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Settings(string hardinessZone)
    {
        var user = await _userManager.GetUserAsync(User);
        if (user is not null)
        {
            user.HardinessZone = hardinessZone;
            await _userManager.UpdateAsync(user);
            TempData["Success"] = "Hardiness zone updated successfully.";
        }
        return RedirectToAction(nameof(Settings));
    }
}
