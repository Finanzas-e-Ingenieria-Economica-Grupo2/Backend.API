namespace TecFinance_Backend.API.Simulation.Domain.Models;

public class Offer
{
    public Offer()
    {
    }
    
    public Offer(List<Payment> payments)
    {
        Payments = payments;
    }
    
    public int Id { get; set; }
    public decimal HomeValue { get; set; }
    public decimal AmountToFinance { get; set; }
    public bool IsHousingSupport { get; set; }
    public bool IsHousingSustainable { get; set; }
    //public bool InitialFee { get; set; }

    public decimal Tea { get; set; }
    public decimal Tna { get; set; }
    public string Capitalization { get; set; }
    public int TermInMonths { get; set; }
    public decimal Tcea { get; set; }
    public decimal Van { get; set; }
    public decimal Tir { get; set; }

    // Relationships
    public int UserId { get; set; }
    public int BankId { get; set; }
    
    public Configuration Configuration { get; set; }

    public List<Payment> Payments { get; set; }
}