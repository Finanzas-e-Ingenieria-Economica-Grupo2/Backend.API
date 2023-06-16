using TecFinance_Backend.API.Simulation.Domain.Models;

namespace TecFinance_Backend.API.Simulation.Domain.Repositories;

public interface IOfferRepository
{
    Task<IEnumerable<Offer>> ListAsync();
    Task<Offer> FindByIdAsync(int id);
    Task AddAsync(Offer offer);
    void Update(Offer offer);
    void Remove(Offer offer);
}