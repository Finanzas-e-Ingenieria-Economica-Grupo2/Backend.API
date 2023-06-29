using TecFinance_Backend.API.Profiles.Domain.Models;
using TecFinance_Backend.API.Shared.Domain.Services.Communication;

namespace TecFinance_Backend.API.Profiles.Domain.Services.Communication;

public class InitialFeeBasedOnHomeValueResponse : BaseResponse<InitialFeeBasedOnHomeValue>
{
    public InitialFeeBasedOnHomeValueResponse(string message) : base(message)
    {
    }

    public InitialFeeBasedOnHomeValueResponse(InitialFeeBasedOnHomeValue resource) : base(resource)
    {
    }
}