using TecFinance_Backend.API.Shared.Domain.Services.Communication;
using TecFinance_Backend.API.Simulation.Domain.Models;

namespace TecFinance_Backend.API.Simulation.Domain.Services.Communication;

public class ConfigurationResponse : BaseResponse<Configuration>
{
    public ConfigurationResponse(string message) : base(message)
    {
    }

    public ConfigurationResponse(Configuration resource) : base(resource)
    {
    }
}