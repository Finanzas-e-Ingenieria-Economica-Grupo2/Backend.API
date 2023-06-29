namespace TecFinance_Backend.API.Profiles.Domain.Models;

public class InitialFeeBasedOnHomeValue
{
    public int Id { get; set; }

    public decimal MinimumHomeValue { get; set; }
    public decimal MaximumHomeValue { get; set; }
    public decimal MinimumInitialFeePercentage { get; set; }
    
    // Relationships
    public int BankId { get; set; }
    public Bank Bank { get; set; }
}