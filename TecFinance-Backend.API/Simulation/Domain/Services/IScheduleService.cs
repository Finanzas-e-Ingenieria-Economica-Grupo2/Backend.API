using TecFinance_Backend.API.Simulation.Domain.Models;
using TecFinance_Backend.API.Simulation.Domain.Services.Communication;

namespace TecFinance_Backend.API.Simulation.Domain.Services;

public interface IScheduleService
{
    Task<IEnumerable<Schedule>> ListAsync();
    Task<ScheduleResponse> SaveAsync(Schedule schedule);
    Task<ScheduleResponse> UpdateAsync(int id, Schedule schedule);
    Task<ScheduleResponse> DeleteAsync(int id);
}