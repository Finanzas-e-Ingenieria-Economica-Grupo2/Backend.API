namespace TecFinance_Backend.API.Simulation.Resources;

public class PaymentResource
{
    public int CurrentPeriod { get; set; }
    public decimal Tep { get; set; }
    public string GracePeriod { get; set; }
    public decimal InitialBalance { get; set; }
    public decimal FinalBalance { get; set; }
    public decimal Interest { get; set; }
    public decimal Amortization { get; set; }
    public decimal Fee { get; set; }
    public decimal TotalFee { get; set; }
    public decimal LienInsurance { get; set; } 
    public decimal PropertyInsurance { get; set; }
    public decimal ValuationExpenses { get; set; }
    public ScheduleResource Schedule { get; set; }
}