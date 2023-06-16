using TecFinance_Backend.API.Profiles.Domain.Models;
using TecFinance_Backend.API.Shared.Domain.Services.Communication;

namespace TecFinance_Backend.API.Profiles.Domain.Services.Communication;

public class UserResponse : BaseResponse<User>
{
    public UserResponse(string message) : base(message)
    {
    }

    public UserResponse(User resource) : base(resource)
    {
    }
}