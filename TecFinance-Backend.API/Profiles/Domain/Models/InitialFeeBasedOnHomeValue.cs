namespace TecFinance_Backend.API.Profiles.Domain.Models;

public class InitialFeeBasedOnHomeValue
{
    public decimal MinimumHomeValue { get; set; }
    public decimal MaximumHomeValue { get; set; }
    public decimal MinimumInitialFeePercentage { get; set; }
    
    // Relationships
    public int BankId { get; set; }
    public Bank Bank { get; set; }
}