namespace TecFinance_Backend.API.Simulation.Domain.Models;

public class Configuration
{
    public int Id { get; set; }
    public string InterestRateType { get; set; }
    public string Currency { get; set; }
    public int AmountTotalGracePeriod { get; set; }
    public int AmountPartialGracePeriod { get; set; }
    
    // Relationships
    public int OfferId { get; set; }
    public Offer Offer { get; set; }
}