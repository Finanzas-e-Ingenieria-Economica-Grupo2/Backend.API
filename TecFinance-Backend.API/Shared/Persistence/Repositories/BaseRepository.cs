using TecFinance_Backend.API.Shared.Persistence.Contexts;

namespace TecFinance_Backend.API.Shared.Persistence.Repositories;

public class BaseRepository
{
    protected readonly AppDbContext _context;

    public BaseRepository(AppDbContext context)
    {
        _context = context;
    }
}