using TecFinance_Backend.API.Shared.Domain.Services.Communication;
using TecFinance_Backend.API.Simulation.Domain.Models;

namespace TecFinance_Backend.API.Simulation.Domain.Services.Communication;

public class PaymentResponse: BaseResponse<Payment>
{
    public PaymentResponse(string message) : base(message)
    {
    }

    public PaymentResponse(Payment resource) : base(resource)
    {
    }
}