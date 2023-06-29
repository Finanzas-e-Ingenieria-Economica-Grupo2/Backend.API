using TecFinance_Backend.API.Simulation.Domain.Models;

namespace TecFinance_Backend.API.Simulation.Domain.Repositories;

public interface IPaymentRepository
{
    Task<IEnumerable<Payment>> ListAsync();
    Task<Payment> FindByIdAsync(int paymentId);
    Task<IEnumerable<Payment>> FindByOfferIdAsync(int offerId);
    Task<Payment> FindLastPaymentByOfferIdAsync(int offerId);
    Task AddAsync(Payment payment);
    void Update(Payment payment);
    void Remove(Payment payment);
}