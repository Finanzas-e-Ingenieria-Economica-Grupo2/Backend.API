using System.ComponentModel.DataAnnotations;

namespace TecFinance_Backend.API.Simulation.Resources;

public class SavePaymentResource
{
    [Required]
    public decimal Tep { get; set; }
    
    [Required]
    [MaxLength(10)]
    public string GracePeriod { get; set; }
    
    [Required]
    public decimal InitialBalance { get; set; }
    
    [Required]
    public decimal FinalBalance { get; set; }
    
    [Required]
    public decimal Interest { get; set; }
    
    [Required]
    public decimal Amortization { get; set; }
    
    [Required]
    public decimal Fee { get; set; }
    
    [Required]
    public decimal TotalFee { get; set; }
    
    [Required]
    public decimal LienInsurance { get; set; } 
    
    [Required]
    public decimal PropertyInsurance { get; set; }
    
    [Required]
    public decimal ValuationExpenses { get; set; }
    
    [Required]
    public int OfferId { get; set; }
}