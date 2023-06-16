using TecFinance_Backend.API.Payments.Domain.Models;
using TecFinance_Backend.API.Payments.Domain.Services.Communication;

namespace TecFinance_Backend.API.Payments.Domain.Services;

public interface IPaymentService
{
    Task<IEnumerable<Payment>> ListAsync();
    Task<IEnumerable<Payment>> ListByScheduleIdAsync(int scheduleId);
    Task<PaymentResponse> SaveAsync(Payment payment);
    // Task<PaymentResponse> UpdateAsync(int paymentId, Payment payment);
    Task<PaymentResponse> DeleteAsync(int paymentId);
}