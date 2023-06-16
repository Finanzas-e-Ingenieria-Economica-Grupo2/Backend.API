using TecFinance_Backend.API.Simulation.Domain.Models;
using TecFinance_Backend.API.Simulation.Domain.Services.Communication;

namespace TecFinance_Backend.API.Simulation.Domain.Services;

public interface IOfferService
{
    Task<IEnumerable<Offer>> ListAsync();
    Task<OfferResponse> SaveAsync(Offer offer);
    Task<OfferResponse> UpdateAsync(int id, Offer offer);
    Task<OfferResponse> DeleteAsync(int id);
}