namespace TecFinance_Backend.API.Simulation.Resources;

public class OfferResource
{
    public int Id { get; set; }
    public decimal HomeValue { get; set; }
    public decimal AmountToFinance { get; set; }
    public bool IsHousingSupport { get; set; }
    public bool IsHousingSustainable { get; set; }
    public decimal Tea { get; set; }
    public decimal Tna { get; set; }
    public string Capitalization { get; set; }
    public int TermInMonths { get; set; }
    public decimal Tcea { get; set; }
    public decimal Van { get; set; }
    public decimal Tir { get; set; }
}