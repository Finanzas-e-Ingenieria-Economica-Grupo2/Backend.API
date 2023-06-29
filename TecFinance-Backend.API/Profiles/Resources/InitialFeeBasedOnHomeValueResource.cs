namespace TecFinance_Backend.API.Profiles.Resources;

public class InitialFeeBasedOnHomeValueResource
{
    public decimal MinimumHomeValue { get; set; }
    public decimal MaximumHomeValue { get; set; }
    public decimal MinimumInitialFeePercentage { get; set; }
}