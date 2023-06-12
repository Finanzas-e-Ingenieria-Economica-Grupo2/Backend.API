using TecFinance_Backend.API.Payments.Domain.Models;

namespace TecFinance_Backend.API.Payments.Domain.Repositories;

public interface IScheduleRepository
{
    Task<IEnumerable<Schedule>> ListAsync();
    Task<Schedule> FindByIdAsync(int id);
    Task AddAsync(Schedule schedule);
    void Update(Schedule schedule);
    void Remove(Schedule schedule);
}