using TecFinance_Backend.API.Simulation.Domain.Models;

namespace TecFinance_Backend.API.Simulation.Domain.Repositories;

public interface IConfigurationRepository
{
    Task<IEnumerable<Configuration>> ListAsync();
    Task<Configuration> FindByIdAsync(int tutorialId);
    Task<IEnumerable<Configuration>> FindByOfferIdAsync(int offerId);
    Task AddAsync(Configuration configuration);
    void Update(Configuration configuration);
    void Remove(Configuration configuration);
}