using TecFinance_Backend.API.Shared.Domain.Services.Communication;
using TecFinance_Backend.API.Simulation.Domain.Models;

namespace TecFinance_Backend.API.Simulation.Domain.Services.Communication;

public class ScheduleResponse: BaseResponse<Schedule>
{
    public ScheduleResponse(string message) : base(message)
    {
    }

    public ScheduleResponse(Schedule resource) : base(resource)
    {
    }
}