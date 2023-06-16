using TecFinance_Backend.API.Shared.Domain.Repositories;
using TecFinance_Backend.API.Simulation.Domain.Models;
using TecFinance_Backend.API.Simulation.Domain.Repositories;
using TecFinance_Backend.API.Simulation.Domain.Services;
using TecFinance_Backend.API.Simulation.Domain.Services.Communication;

namespace TecFinance_Backend.API.Simulation.Services;

public class PaymentService: IPaymentService
{
    private readonly IPaymentRepository _paymentRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IOfferRepository _offerRepository;

    public PaymentService(IPaymentRepository paymentRepository, IUnitOfWork unitOfWork, IOfferRepository offerRepository)
    {
        _paymentRepository = paymentRepository;
        _unitOfWork = unitOfWork;
        _offerRepository = offerRepository;
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
        // Validate existence of assigned offer
        
        var existingOffer = await _offerRepository.FindByIdAsync(payment.OfferId);
        
        if (existingOffer == null)
            return new PaymentResponse("Invalid offer.");
        
        // Determine the new position for the payment
        
        var newPosition = 1; // Default position if there are no existing payments
        var lastPayment = await _paymentRepository.FindLastPaymentByScheduleIdAsync(payment.OfferId);
        if (lastPayment != null)
            newPosition = lastPayment.CurrentPeriod + 1;

        // Assign the new position to the payment
        payment.CurrentPeriod = newPosition;

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