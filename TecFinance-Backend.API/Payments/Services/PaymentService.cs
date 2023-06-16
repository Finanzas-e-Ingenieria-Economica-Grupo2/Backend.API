using TecFinance_Backend.API.Payments.Domain.Models;
using TecFinance_Backend.API.Payments.Domain.Repositories;
using TecFinance_Backend.API.Payments.Domain.Services;
using TecFinance_Backend.API.Payments.Domain.Services.Communication;
using TecFinance_Backend.API.Shared.Domain.Repositories;

namespace TecFinance_Backend.API.Payments.Services;

public class PaymentService: IPaymentService
{
    private readonly IPaymentRepository _paymentRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IScheduleRepository _scheduleRepository;

    public PaymentService(IPaymentRepository paymentRepository, IUnitOfWork unitOfWork, IScheduleRepository scheduleRepository)
    {
        _paymentRepository = paymentRepository;
        _unitOfWork = unitOfWork;
        _scheduleRepository = scheduleRepository;
    }

    public async Task<IEnumerable<Payment>> ListAsync()
    {
        return await _paymentRepository.ListAsync();
    }

    public async Task<IEnumerable<Payment>> ListByScheduleIdAsync(int scheduleId)
    {
        return await _paymentRepository.FindByScheduleIdAsync(scheduleId);
    }

    public async Task<PaymentResponse> SaveAsync(Payment payment)
    {
        // Validate existence of assigned schedule
        
        var existingSchedule = await _scheduleRepository.FindByIdAsync(payment.ScheduleId);
        
        if (existingSchedule == null)
            return new PaymentResponse("Invalid schedule.");

        // Perform adding
        
        try
        {
            await _paymentRepository.AddAsync(payment);
            await _unitOfWork.CompleteAsync();
            
            return new PaymentResponse(payment);
        }
        catch (Exception e)
        {
            // Do some logging stuff
            return new PaymentResponse($"An error occurred while saving the payment: {e.Message}");
        }
    }

    public Task<PaymentResponse> UpdateAsync(int paymentId, Payment payment)
    {
        throw new NotImplementedException();
    }

    public async Task<PaymentResponse> DeleteAsync(int paymentId)
    {
        // Validate if payments exists
        
        var existingPayment = await _paymentRepository.FindByIdAsync(paymentId);
        
        if (existingPayment == null)
            return new PaymentResponse("Payment not found.");
        
        // Perform delete
        
        try
        {
            _paymentRepository.Remove(existingPayment);
            await _unitOfWork.CompleteAsync();
            
            return new PaymentResponse(existingPayment);
        }
        catch (Exception e)
        {
            // Error handling
            return new PaymentResponse($"An error occurred while deleting the payment: {e.Message}");
        }
    }
}