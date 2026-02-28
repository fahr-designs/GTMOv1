using System.ComponentModel.DataAnnotations;
using GardenKeeper.Domain.Enums;

namespace GardenKeeper.Application.ViewModels;

public class LogEntryCreateViewModel
{
    [Required]
    [Display(Name = "Garden Bed")]
    public int BedId { get; set; }

    [Display(Name = "Plant (optional)")]
    public int? PlantId { get; set; }

    [Required]
    [Display(Name = "Entry Date")]
    [DataType(DataType.Date)]
    public DateTime EntryDate { get; set; } = DateTime.Today;

    [Required]
    [Display(Name = "Entry Type")]
    public LogEntryType EntryType { get; set; }

    [Display(Name = "Start Method")]
    public StartMethod? StartMethod { get; set; }

    [Display(Name = "Expected Harvest Date")]
    [DataType(DataType.Date)]
    public DateTime? ExpectedHarvestDate { get; set; }

    [Required, StringLength(2000)]
    public string Notes { get; set; } = string.Empty;
}
