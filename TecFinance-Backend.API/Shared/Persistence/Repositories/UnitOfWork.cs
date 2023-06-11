using TecFinance_Backend.API.Shared.Domain.Repositories;
using TecFinance_Backend.API.Shared.Persistence.Contexts;

namespace TecFinance_Backend.API.Shared.Persistence.Repositories;

public class UnitOfWork: IUnitOfWork
{
    private readonly AppDbContext _context;
    
    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }

    public async Task CompleteAsync()
    {
        await _context.SaveChangesAsync();
    }
}