using Microsoft.EntityFrameworkCore;
using TecFinance_Backend.API.Profiles.Domain.Models;
using TecFinance_Backend.API.Profiles.Domain.Repositories;
using TecFinance_Backend.API.Shared.Persistence.Contexts;
using TecFinance_Backend.API.Shared.Persistence.Repositories;

namespace TecFinance_Backend.API.Profiles.Persistence.Repositories;

public class TermForPaymentsRepository : BaseRepository, ITermForPaymentsRepository
{
    public TermForPaymentsRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<TermForPayments>> ListAsync()
    {
        return await _context.TermForPaymentsDbSet.ToListAsync();
    }

    public async Task<TermForPayments> FindByIdAsync(int termId)
    {
        return await _context.TermForPaymentsDbSet.FindAsync(termId);
    }

    public async Task AddAsync(TermForPayments term)
    {
        await _context.TermForPaymentsDbSet.AddAsync(term);
    }

    public void Update(TermForPayments term)
    {
        _context.TermForPaymentsDbSet.Update(term);
    }

    public void Remove(TermForPayments term)
    {
        _context.TermForPaymentsDbSet.Remove(term);
    }
}