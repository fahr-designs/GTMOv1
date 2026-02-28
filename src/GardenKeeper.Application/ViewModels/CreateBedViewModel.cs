using System.ComponentModel.DataAnnotations;

namespace GardenKeeper.Application.ViewModels;

public class CreateBedViewModel
{
    [Required, StringLength(100)]
    public string Name { get; set; } = string.Empty;

    [Required, Range(1, 50)]
    [Display(Name = "Width (feet)")]
    public int WidthFeet { get; set; } = 4;

    [Required, Range(1, 100)]
    [Display(Name = "Length (feet)")]
    public int LengthFeet { get; set; } = 8;
}
