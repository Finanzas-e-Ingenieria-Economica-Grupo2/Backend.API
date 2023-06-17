using TecFinance_Backend.API.Simulation.Domain.Models;
using TecFinance_Backend.API.Simulation.Domain.Services.Communication;

namespace TecFinance_Backend.API.Simulation.Domain.Services;

public interface IConfigurationService
{
    Task<IEnumerable<Configuration>> ListAsync();
    Task<ConfigurationResponse> SaveAsync(Configuration configuration);
    Task<ConfigurationResponse> UpdateAsync(int configurationId, Configuration configuration);
    Task<ConfigurationResponse> DeleteAsync(int configurationId);
}