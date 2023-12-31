﻿using TecFinance_Backend.API.Simulation.Domain.Models;
using TecFinance_Backend.API.Simulation.Domain.Services.Communication;

namespace TecFinance_Backend.API.Simulation.Domain.Services;

public interface IPaymentService
{
    Task<IEnumerable<Payment>> ListAsync();
    Task<IEnumerable<Payment>> ListByOfferIdAsync(int offerId);
    Task<PaymentResponse> SaveAsync(Payment payment);
    // Task<PaymentResponse> UpdateAsync(int paymentId, Payment payment);
    Task<PaymentResponse> DeleteAsync(int paymentId);
}