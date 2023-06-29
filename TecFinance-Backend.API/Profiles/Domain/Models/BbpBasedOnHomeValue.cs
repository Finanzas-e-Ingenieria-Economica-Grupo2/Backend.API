namespace TecFinance_Backend.API.Profiles.Domain.Models;

public class BbpBasedOnHomeValue
{
    public decimal MinimumHomeValue { get; set; }
    public decimal MaximumHomeValue { get; set; }
    public decimal BbpTraditional { get; set; }
    public decimal BbpSustainable { get; set; }
    
    // Relationships
    public int BankId { get; set; }
    public Bank Bank { get; set; }
}