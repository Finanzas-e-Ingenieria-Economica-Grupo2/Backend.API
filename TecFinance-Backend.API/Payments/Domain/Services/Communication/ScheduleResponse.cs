using TecFinance_Backend.API.Payments.Domain.Models;
using TecFinance_Backend.API.Shared.Domain.Services.Communication;

namespace TecFinance_Backend.API.Payments.Domain.Services.Communication;

public class ScheduleResponse: BaseResponse<Schedule>
{
    public ScheduleResponse(string message) : base(message)
    {
    }

    public ScheduleResponse(Schedule resource) : base(resource)
    {
    }
}