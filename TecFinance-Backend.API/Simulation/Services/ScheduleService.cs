using TecFinance_Backend.API.Simulation.Domain.Models;
using TecFinance_Backend.API.Simulation.Domain.Services;
using TecFinance_Backend.API.Simulation.Domain.Services.Communication;

namespace TecFinance_Backend.API.Simulation.Services;

public class ScheduleService : IScheduleService
{
    public Task<IEnumerable<Schedule>> ListAsync()
    {
        throw new NotImplementedException();
    }

    public Task<ScheduleResponse> SaveAsync(Schedule schedule)
    {
        throw new NotImplementedException();
    }

    public Task<ScheduleResponse> UpdateAsync(int id, Schedule schedule)
    {
        throw new NotImplementedException();
    }

    public Task<ScheduleResponse> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}