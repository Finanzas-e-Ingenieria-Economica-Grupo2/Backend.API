namespace TecFinance_Backend.API.Simulation.Domain.Models;

public class Payment
{
    public int Id { get; set; }
    public int CurrentPeriod { get; set; }
    public decimal Tea { get; set; }
    public decimal Tep { get; set; }
    public string GracePeriod { get; set; }
    public decimal InitialBalance { get; set; }
    public decimal FinalBalance { get; set; }
    public decimal Interest { get; set; }
    public decimal Amortization { get; set; }
    public decimal Quota { get; set; }
    public decimal TotalQuota { get; set; }
    
    public decimal LienInsurance { get; set; }
    public decimal PropertyInsurance { get; set; }
    public decimal AppraisalExpenses { get; set; }

    
    // Relationships
    public int OfferId { get; set; }
    public Offer Offer { get; set; }
}