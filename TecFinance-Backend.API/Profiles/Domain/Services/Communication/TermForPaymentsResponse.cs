using TecFinance_Backend.API.Profiles.Domain.Models;
using TecFinance_Backend.API.Shared.Domain.Services.Communication;

namespace TecFinance_Backend.API.Profiles.Domain.Services.Communication;

public class TermForPaymentsResponse : BaseResponse<TermForPayments>
{
    public TermForPaymentsResponse(string message) : base(message)
    {
    }

    public TermForPaymentsResponse(TermForPayments resource) : base(resource)
    {
    }
}