using Microsoft.EntityFrameworkCore;
using TecFinance_Backend.API.Shared.Persistence.Contexts;
using TecFinance_Backend.API.Shared.Persistence.Repositories;
using TecFinance_Backend.API.Simulation.Domain.Models;
using TecFinance_Backend.API.Simulation.Domain.Repositories;

namespace TecFinance_Backend.API.Simulation.Persistence.Repositories;

public class PaymentRepository: BaseRepository, IPaymentRepository
{
    public PaymentRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Payment>> ListAsync()
    {
        return await _context.Payments
            .Include(p => p.Offer)
            .ToListAsync();
    }
    
    public async Task<Payment> FindByIdAsync(int paymentId)
    {
        return await _context.Payments
            .Include(p => p.Offer)
            .FirstOrDefaultAsync(p => p.Id == paymentId);
    }

    public async Task<IEnumerable<Payment>> FindByScheduleIdAsync(int scheduleId)
    {
        return await _context.Payments
            .Where(p => p.OfferId == scheduleId)
            .Include(p => p.Offer)
            .ToListAsync();
    }

    public async Task<Payment> FindLastPaymentByScheduleIdAsync(int scheduleId)
    {
        return await _context.Payments
            .Where(p => p.OfferId == scheduleId)
            .Include(p => p.Offer)
            .OrderByDescending(p=>p.CurrentPeriod)
            .FirstOrDefaultAsync();
    }

    public async Task AddAsync(Payment payment)
    {
        await _context.Payments.AddAsync(payment);
    }

    public void Update(Payment payment)
    {
        _context.Update(payment);
    }

    public void Remove(Payment payment)
    {
        _context.Remove(payment);
    }
}