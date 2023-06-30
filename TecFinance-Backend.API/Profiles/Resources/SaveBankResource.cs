using System.ComponentModel.DataAnnotations;
using TecFinance_Backend.API.Profiles.Domain.Models;

namespace TecFinance_Backend.API.Profiles.Resources;

public class SaveBankResource
{
    [Required]
    [MaxLength(50)]
    public string Name { get; set; }
    
    [Required]
    public decimal MinimumLoan { get; set; }
    [Required]
    public decimal MaximumLoan { get; set; }
    
    // [Required]
    // public List<SaveBbpBasedOnHomeValueResource> BbpBasedOnHomeValue { get; set; }
    // [Required]
    // public List<SaveInitialFeeBasedOnHomeValueResource> InitialFeeBasedOnHomeValue { get; set; }
    
    [Required]
    public decimal LienInsurance { get; set; } 
    [Required]
    public decimal PropertyInsurance { get; set; }
    [Required]
    public decimal AppraisalExpenses { get; set; }
    
    // [Required]
    // public SaveTermForPaymentsResource TermForPayments { get; set; }
}