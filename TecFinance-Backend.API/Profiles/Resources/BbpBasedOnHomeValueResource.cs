namespace TecFinance_Backend.API.Profiles.Resources;

public class BbpBasedOnHomeValueResource
{
    public decimal MinimumHomeValue { get; set; }
    public decimal MaximumHomeValue { get; set; }
    public decimal BbpTraditional { get; set; }
    public decimal BbpSustainable { get; set; }
}