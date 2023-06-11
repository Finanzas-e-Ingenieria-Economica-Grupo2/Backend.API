using TecFinance_Backend.API.Payments.Domain.Models;
using TecFinance_Backend.API.Payments.Domain.Services.Communication;

namespace TecFinance_Backend.API.Payments.Domain.Services;

public interface IPaymentService
{
    Task<IEnumerable<Payment>> ListAsync();
    Task<IEnumerable<Payment>> ListByScheduleIdAsync();
    Task<PaymentResponse> SaveAsync(Payment payment);
    Task<PaymentResponse> UpdateAsync(int id, Payment payment);
    Task<PaymentResponse> DeleteAsync(int id);
}