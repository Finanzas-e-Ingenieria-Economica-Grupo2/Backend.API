using TecFinance_Backend.API.Profiles.Domain.Models;
using TecFinance_Backend.API.Shared.Domain.Services.Communication;

namespace TecFinance_Backend.API.Profiles.Domain.Services.Communication;

public class BbpBasedOnHomeValueResponse : BaseResponse<BbpBasedOnHomeValue>
{
    public BbpBasedOnHomeValueResponse(string message) : base(message)
    {
    }

    public BbpBasedOnHomeValueResponse(BbpBasedOnHomeValue resource) : base(resource)
    {
    }
}