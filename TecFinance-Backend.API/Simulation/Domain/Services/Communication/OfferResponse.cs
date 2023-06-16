using TecFinance_Backend.API.Shared.Domain.Services.Communication;
using TecFinance_Backend.API.Simulation.Domain.Models;

namespace TecFinance_Backend.API.Simulation.Domain.Services.Communication;

public class OfferResponse: BaseResponse<Offer>
{
    public OfferResponse(string message) : base(message)
    {
    }

    public OfferResponse(Offer resource) : base(resource)
    {
    }
}