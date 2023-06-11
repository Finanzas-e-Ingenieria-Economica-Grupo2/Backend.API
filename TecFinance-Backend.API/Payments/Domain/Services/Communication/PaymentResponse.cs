using TecFinance_Backend.API.Payments.Domain.Models;
using TecFinance_Backend.API.Shared.Domain.Services.Communication;

namespace TecFinance_Backend.API.Payments.Domain.Services.Communication;

public class PaymentResponse: BaseResponse<Payment>
{
    public PaymentResponse(string message) : base(message)
    {
    }

    public PaymentResponse(Payment resource) : base(resource)
    {
    }
}