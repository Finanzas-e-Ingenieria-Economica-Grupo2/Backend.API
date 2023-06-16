namespace TecFinance_Backend.API.Profiles.Resources;

public class BankResource
{
    public int Id { get; set; }
    public string Name { get; set; }
    
    // Seguro de Desgravamen
    public decimal LienInsurance { get; set; } 
    // Seguro de Inmueble
    public decimal PropertyInsurance { get; set; }
    // Gastos de tasación
    public decimal ValuationExpenses { get; set; }
    
    public decimal TraditionalBbp { get; set; }
    public decimal SustainableBbp { get; set; }
    public decimal MinimumInitialFee { get; set; }
    public int MaximumPeriod { get; set; }
    public int MinimumPeriod { get; set; }
}