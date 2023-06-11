using TecFinance_Backend.API.Payments.Domain.Models;

namespace TecFinance_Backend.API.Payments.Domain.Repositories;

public interface IPaymentRepository
{
    Task<IEnumerable<Payment>> ListAsync();
    Task<IEnumerable<Payment>> ListByScheduleIdAsync();
    Task<Payment> FindByIdAsync(int id);
    Task AddAsync(Payment payment);
    void Update(Payment category);
    void Remove(Payment category);
}