﻿using System.ComponentModel.DataAnnotations;

namespace TecFinance_Backend.API.Simulation.Resources;

public class SavePaymentResource
{
    [Required]
    public int CurrentPeriod { get; set; }
    
    [Required]
    public decimal Tea { get; set; }
    
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
    public decimal Quota { get; set; }
    
    [Required]
    public decimal TotalQuota { get; set; }
    
    [Required]
    public decimal LienInsurance { get; set; }
    
    [Required]
    public decimal PropertyInsurance { get; set; }
    
    [Required]
    public decimal AppraisalExpenses { get; set; }
    
    // Relationships
    [Required]
    public int OfferId { get; set; }
}