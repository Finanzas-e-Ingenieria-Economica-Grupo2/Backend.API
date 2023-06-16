using TecFinance_Backend.API.Simulation.Domain.Models;

namespace TecFinance_Backend.API.Simulation.Domain.Repositories;

public interface IPaymentRepository
{
    Task<IEnumerable<Payment>> ListAsync();
    Task<Payment> FindByIdAsync(int paymentId);
    Task<IEnumerable<Payment>> FindByScheduleIdAsync(int scheduleId);
    Task<Payment> FindLastPaymentByScheduleIdAsync(int scheduleId);
    Task AddAsync(Payment payment);
    void Update(Payment payment);
    void Remove(Payment payment);
}