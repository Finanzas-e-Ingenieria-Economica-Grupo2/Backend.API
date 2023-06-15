using TecFinance_Backend.API.Profiles.Domain.Models;
using TecFinance_Backend.API.Shared.Domain.Services.Communication;

namespace TecFinance_Backend.API.Profiles.Domain.Services.Communication;

public class BankResponse : BaseResponse<Bank>
{
    public BankResponse(string message) : base(message)
    {
    }

    public BankResponse(Bank resource) : base(resource)
    {
    }
}