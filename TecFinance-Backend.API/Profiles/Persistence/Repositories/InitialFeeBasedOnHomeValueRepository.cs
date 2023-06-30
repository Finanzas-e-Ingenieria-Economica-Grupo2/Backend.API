using Microsoft.EntityFrameworkCore;
using TecFinance_Backend.API.Profiles.Domain.Models;
using TecFinance_Backend.API.Profiles.Domain.Repositories;
using TecFinance_Backend.API.Shared.Persistence.Contexts;
using TecFinance_Backend.API.Shared.Persistence.Repositories;

namespace TecFinance_Backend.API.Profiles.Persistence.Repositories;

public class InitialFeeBasedOnHomeValueRepository : BaseRepository, IInitialFeeBasedOnHomeValueRepository
{
    public InitialFeeBasedOnHomeValueRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<InitialFeeBasedOnHomeValue>> ListAsync()
    {
        return await _context.InitialFeeBasedOnHomeValues.ToListAsync();
    }

    public async Task<InitialFeeBasedOnHomeValue> FindByIdAsync(int initialId)
    {
        return await _context.InitialFeeBasedOnHomeValues.FindAsync(initialId);
    }

    public async Task AddAsync(InitialFeeBasedOnHomeValue initialFee)
    {
        await _context.InitialFeeBasedOnHomeValues.AddAsync(initialFee);
    }

    public void Update(InitialFeeBasedOnHomeValue initialFee)
    {
        _context.InitialFeeBasedOnHomeValues.Update(initialFee);
    }

    public void Remove(InitialFeeBasedOnHomeValue initialFee)
    {
        _context.InitialFeeBasedOnHomeValues.Remove(initialFee);
    }
}