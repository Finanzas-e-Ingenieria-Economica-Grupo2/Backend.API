namespace TecFinance_Backend.API.Simulation.Resources;

public class ConfigurationResource
{
    public int Id { get; set; }
    public string InterestRateType { get; set; }
    public string Currency { get; set; }
    public int AmountTotalGracePeriod { get; set; }
    public int AmountPartialGracePeriod { get; set; }
}