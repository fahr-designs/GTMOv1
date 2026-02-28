using Microsoft.AspNetCore.Identity;

namespace GardenKeeper.Infrastructure.Identity;

public class ApplicationUser : IdentityUser
{
    public string? HardinessZone { get; set; }
}
