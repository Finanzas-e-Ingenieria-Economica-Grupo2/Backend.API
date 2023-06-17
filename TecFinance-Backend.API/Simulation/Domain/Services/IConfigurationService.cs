using TecFinance_Backend.API.Simulation.Domain.Models;
using TecFinance_Backend.API.Simulation.Domain.Services.Communication;

namespace TecFinance_Backend.API.Simulation.Domain.Services;

public interface IConfigurationService
{
    Task<IEnumerable<Configuration>> ListAsync();
    Task<ConfigurationResponse> SaveAsync(Configuration tutorial);
    Task<ConfigurationResponse> UpdateAsync(int tutorialId, Configuration tutorial);
    Task<ConfigurationResponse> DeleteAsync(int tutorialId);
}