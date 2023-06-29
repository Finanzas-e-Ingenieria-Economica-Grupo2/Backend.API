using TecFinance_Backend.API.Profiles.Domain.Models;

namespace TecFinance_Backend.API.Profiles.Resources;

public class BankResource
{
    public int Id { get; set; }
    public string Name { get; set; }
    
    public decimal MinimumLoan { get; set; }
    public decimal MaximumLoan { get; set; }
    
    //public List<BbpBasedOnHomeValue> BbpBasedOnHomeValue { get; set; }
    //public List<InitialFeeBasedOnHomeValue> InitialFeeBasedOnHomeValue { get; set; }
    
    public decimal LienInsurance { get; set; } 
    public decimal PropertyInsurance { get; set; }
    public decimal AppraisalExpenses { get; set; }
    
    //public TermForPayments TermForPayments { get; set; }
}