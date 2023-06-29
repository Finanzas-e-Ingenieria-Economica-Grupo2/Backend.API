using System.ComponentModel.DataAnnotations;

namespace TecFinance_Backend.API.Simulation.Resources;

public class SaveOfferResource
{
    [Required]
    [MaxLength(10)]
    public string Currency { get; set; }
    
    [Required]
    [MaxLength(50)]
    public string InterestRateType { get; set; }
    
    [Required]
    public decimal HomeValue { get; set; }
    
    [Required]
    public decimal InitialFee { get; set; }
    
    [Required]
    public decimal AmountToFinance { get; set; }
    
    [Required]
    public decimal BbpTotal { get; set; }
    
    [Required]
    public bool IsHousingSupport { get; set; }
    
    [Required]
    public bool IsHousingSustainable { get; set; }
    
    [Required]
    public decimal Tea { get; set; }
    
    [Required]
    public decimal Tna { get; set; }
    
    [Required]
    [MaxLength(20)]
    public string Capitalization { get; set; }
    
    [Required]
    [MaxLength(20)]
    public string Frequency { get; set; }
    
    [Required]
    public int TermInMonths { get; set; }
    
    [Required]
    public decimal Tcea { get; set; }
    
    [Required]
    public decimal Van { get; set; }
    
    [Required]
    public decimal Tir { get; set; }

    // Relationships
    [Required]
    public int UserId { get; set; }
    
    [Required]
    public int BankId { get; set; }
    
    //public List<Payment> Payments { get; set; }
}