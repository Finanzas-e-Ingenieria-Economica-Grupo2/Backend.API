using System.ComponentModel.DataAnnotations;

namespace TecFinance_Backend.API.Profiles.Resources;

public class SaveInitialFeeBasedOnHomeValueResource
{
    [Required]
    public decimal MinimumHomeValue { get; set; }
    
    [Required]
    public decimal MaximumHomeValue { get; set; }
    
    [Required]
    public decimal MinimumInitialFeePercentage { get; set; }
    
    // Relationships
    [Required]
    public int BankId { get; set; }
}