using TecFinance_Backend.API.Payments.Domain.Models;

namespace TecFinance_Backend.API.Payments.Domain.Repositories;

public interface IScheduleRepository
{
    Task<IEnumerable<Schedule>> ListAsync();
    Task<Schedule> FindByIdAsync(int id);
    Task AddAsync(Schedule payment);
    void Update(Schedule category);
    void Remove(Schedule category);
}