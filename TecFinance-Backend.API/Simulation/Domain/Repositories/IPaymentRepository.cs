using TecFinance_Backend.API.Simulation.Domain.Models;

namespace TecFinance_Backend.API.Simulation.Domain.Repositories;

public interface IPaymentRepository
{
    Task<IEnumerable<Payment>> ListAsync();
    Task<IEnumerable<Payment>> FindByScheduleIdAsync(int scheduleId);
    Task<Payment> FindByIdAsync(int paymentId);
    Task AddAsync(Payment payment);
    void Update(Payment payment);
    void Remove(Payment payment);
}