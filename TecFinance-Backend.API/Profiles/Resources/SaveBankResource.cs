using System.ComponentModel.DataAnnotations;

namespace TecFinance_Backend.API.Profiles.Resources;

public class SaveBankResource
{
    [Required]
    [MaxLength(50)]
    public string Name { get; set; }
    
    // Seguro de Desgravamen
    [Required]
    public decimal LienInsurance { get; set; } 
    
    // Seguro de Inmueble
    [Required]
    public decimal PropertyInsurance { get; set; }
    
    // Gastos de tasación
    [Required]
    public decimal ValuationExpenses { get; set; }
    
    [Required]
    public decimal TraditionalBbp { get; set; }
    
    [Required]
    public decimal SustainableBbp { get; set; }
    
    [Required]
    public decimal MinimumInitialFee { get; set; }
    
    [Required]
    public int MaximumPeriod { get; set; }
    
    [Required]
    public int MinimumPeriod { get; set; }
}