using System.ComponentModel.DataAnnotations;

namespace TecFinance_Backend.API.Profiles.Resources;

public class SaveTermForPaymentsResource
{
    [Required]
    public int MinimumTerm { get; set; }
    
    [Required]
    public int MaximumTerm { get; set; }
    
    // Relationships
    [Required]
    public int BankId { get; set; }
}