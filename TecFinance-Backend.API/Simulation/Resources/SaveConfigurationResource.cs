using System.ComponentModel.DataAnnotations;

namespace TecFinance_Backend.API.Simulation.Resources;

public class SaveConfigurationResource
{
    [Required]
    [MaxLength(10)]
    public string InterestRateType { get; set; }
    
    [Required]
    [MaxLength(10)]
    public string Currency { get; set; }
    
    [Required]
    public int AmountTotalGracePeriod { get; set; }
    
    [Required]
    public int AmountPartialGracePeriod { get; set; }
    
    [Required]
    public int OfferId { get; set; }
}