﻿namespace TecFinance_Backend.API.Simulation.Domain.Models;

public class Payment
{
    // Missing currency
    public int Id { get; set; }
    public int CurrentPeriod { get; set; }
    public decimal Tep { get; set; }
    public string GracePeriod { get; set; }
    public decimal InitialBalance { get; set; }
    public decimal FinalBalance { get; set; }
    public decimal Interest { get; set; }
    public decimal Amortization { get; set; }
    public decimal Fee { get; set; }
    public decimal TotalFee { get; set; }

    // Seguro de Desgravamen
    public decimal LienInsurance { get; set; } 
    // Seguro de Inmueble
    public decimal PropertyInsurance { get; set; }
    // Gasto de tasación
    public decimal ValuationExpenses { get; set; }

    
    // Relationships
    public int OfferId { get; set; }
    public Offer Offer { get; set; }

}