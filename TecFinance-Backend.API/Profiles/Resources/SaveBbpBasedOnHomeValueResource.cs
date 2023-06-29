using System.ComponentModel.DataAnnotations;

namespace TecFinance_Backend.API.Profiles.Resources;

public class SaveBbpBasedOnHomeValueResource
{
    [Required]
    public decimal MinimumHomeValue { get; set; }
    
    [Required]
    public decimal MaximumHomeValue { get; set; }
    
    [Required]
    public decimal BbpTraditional { get; set; }
    
    [Required]
    public decimal BbpSustainable { get; set; }
    
    // Relationships
    [Required]
    public int BankId { get; set; }
}