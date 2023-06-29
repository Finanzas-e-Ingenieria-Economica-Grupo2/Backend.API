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

    public Task<IEnumerable<BbpBasedOnHomeValue>> ListAsync()
    {
        throw new NotImplementedException();
    }

    public Task<BbpBasedOnHomeValue> FindByIdAsync(int bbpId)
    {
        throw new NotImplementedException();
    }

    public Task AddAsync(BbpBasedOnHomeValue bank)
    {
        throw new NotImplementedException();
    }

    public void Update(BbpBasedOnHomeValue bank)
    {
        throw new NotImplementedException();
    }

    public void Remove(BbpBasedOnHomeValue bank)
    {
        throw new NotImplementedException();
    }
}