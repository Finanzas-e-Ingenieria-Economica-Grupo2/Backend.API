using Microsoft.EntityFrameworkCore;
using TecFinance_Backend.API.Shared.Persistence.Contexts;
using TecFinance_Backend.API.Shared.Persistence.Repositories;
using TecFinance_Backend.API.Simulation.Domain.Models;
using TecFinance_Backend.API.Simulation.Domain.Repositories;

namespace TecFinance_Backend.API.Simulation.Persistence.Repositories;

public class OfferRepository: BaseRepository, IOfferRepository
{
    public OfferRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Offer>> ListAsync()
    {
        return await _context.Offers.ToListAsync();
    }

    public async Task<Offer> FindByIdAsync(int id)
    {
        return await _context.Offers.FindAsync(id);
    }

    public async Task AddAsync(Offer offer)
    {
        await _context.Offers.AddAsync(offer);
    }

    public void Update(Offer offer)
    {
        _context.Offers.Update(offer);
    }

    public void Remove(Offer offer)
    {
        _context.Offers.Remove(offer);
    }
}