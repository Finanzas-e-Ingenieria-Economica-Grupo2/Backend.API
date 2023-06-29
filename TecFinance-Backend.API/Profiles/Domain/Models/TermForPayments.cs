namespace TecFinance_Backend.API.Profiles.Domain.Models;

public class TermForPayments
{
    public int MinimumTerm { get; set; }
    public int MaximumTerm { get; set; }
    
    // Relationships
    public int BankId { get; set; }
    public Bank Bank { get; set; }
}