using Microsoft.EntityFrameworkCore;
using TecFinance_Backend.API.Shared.Persistence.Contexts;
using TecFinance_Backend.API.Shared.Persistence.Repositories;
using TecFinance_Backend.API.Simulation.Domain.Models;
using TecFinance_Backend.API.Simulation.Domain.Repositories;

namespace TecFinance_Backend.API.Simulation.Persistence.Repositories;

public class ConfigurationRepository : BaseRepository, IConfigurationRepository
{
    public ConfigurationRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Configuration>> ListAsync()
    {
        return await _context.Configurations.ToListAsync();
    }

    public async Task<Configuration> FindByIdAsync(int configurationId)
    {
        return await _context.Configurations
            .Include(c => c.Offer)
            .FirstOrDefaultAsync(c => c.Id == configurationId);    
    }

    public async Task<Configuration> FindByOfferIdAsync(int offerId)
    {
        return await _context.Configurations
            .Include(c => c.Offer)
            .FirstOrDefaultAsync(c => c.OfferId == offerId);    
    }

    public async Task AddAsync(Configuration configuration)
    {
        await _context.Configurations.AddAsync(configuration);
    }

    public void Update(Configuration configuration)
    {
        _context.Update(configuration);
    }

    public void Remove(Configuration configuration)
    {
        _context.Remove(configuration);
    }
}