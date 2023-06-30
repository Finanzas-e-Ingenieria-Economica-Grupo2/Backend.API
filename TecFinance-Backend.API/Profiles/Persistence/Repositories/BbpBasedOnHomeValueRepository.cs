using Microsoft.EntityFrameworkCore;
using TecFinance_Backend.API.Profiles.Domain.Models;
using TecFinance_Backend.API.Profiles.Domain.Repositories;
using TecFinance_Backend.API.Shared.Persistence.Contexts;
using TecFinance_Backend.API.Shared.Persistence.Repositories;

namespace TecFinance_Backend.API.Profiles.Persistence.Repositories;

public class BbpBasedOnHomeValueRepository : BaseRepository, IBbpBasedOnHomeValueRepository
{
    public BbpBasedOnHomeValueRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<BbpBasedOnHomeValue>> ListAsync()
    {
        return await _context.BbpBasedOnHomeValues.ToListAsync();
    }

    public async Task<BbpBasedOnHomeValue> FindByIdAsync(int bbpId)
    {
        return await _context.BbpBasedOnHomeValues.FindAsync(bbpId);
    }

    public async Task<BbpBasedOnHomeValue> FindByBankIdAsync(int bankId)
    {
        return await _context.BbpBasedOnHomeValues
            .FirstOrDefaultAsync(b => b.BankId == bankId);
    }

    public async Task AddAsync(BbpBasedOnHomeValue bbp)
    {
        await _context.BbpBasedOnHomeValues.AddAsync(bbp);
    }

    public void Update(BbpBasedOnHomeValue bbp)
    {
        _context.BbpBasedOnHomeValues.Update(bbp);
    }

    public void Remove(BbpBasedOnHomeValue bbp)
    {
        _context.BbpBasedOnHomeValues.Remove(bbp);
    }
}