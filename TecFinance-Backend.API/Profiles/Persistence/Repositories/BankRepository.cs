using Microsoft.EntityFrameworkCore;
using TecFinance_Backend.API.Profiles.Domain.Models;
using TecFinance_Backend.API.Profiles.Domain.Repositories;
using TecFinance_Backend.API.Shared.Persistence.Contexts;
using TecFinance_Backend.API.Shared.Persistence.Repositories;

namespace TecFinance_Backend.API.Profiles.Persistence.Repositories;

public class BankRepository : BaseRepository, IBankRepository
{
    public BankRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Bank>> ListAsync()
    {
        return await _context.Banks.ToListAsync();
    }

    public async Task<Bank> FindByIdAsync(int bankId)
    {
        return await _context.Banks.FindAsync(bankId);
    }

    public async Task AddAsync(Bank bank)
    {
        await _context.Banks.AddAsync(bank);
    }

    public void Update(Bank bank)
    {
        _context.Banks.Update(bank);
    }

    public void Remove(Bank bank)
    {
        _context.Banks.Remove(bank);
    }
}