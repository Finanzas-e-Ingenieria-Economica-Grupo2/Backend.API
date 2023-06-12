using Microsoft.EntityFrameworkCore;
using TecFinance_Backend.API.Payments.Domain.Models;
using TecFinance_Backend.API.Payments.Domain.Repositories;
using TecFinance_Backend.API.Shared.Persistence.Contexts;
using TecFinance_Backend.API.Shared.Persistence.Repositories;

namespace TecFinance_Backend.API.Payments.Persistence.Repositories;

public class ScheduleRepository: BaseRepository, IScheduleRepository
{
    public ScheduleRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Schedule>> ListAsync()
    {
        return await _context.Schedules.ToListAsync();
    }

    public async Task<Schedule> FindByIdAsync(int id)
    {
        return await _context.Schedules.FindAsync(id);
    }

    public async Task AddAsync(Schedule schedule)
    {
        await _context.Schedules.AddAsync(schedule);
    }

    public void Update(Schedule schedule)
    {
        _context.Schedules.Update(schedule);
    }

    public void Remove(Schedule schedule)
    {
        _context.Schedules.Remove(schedule);
    }
}