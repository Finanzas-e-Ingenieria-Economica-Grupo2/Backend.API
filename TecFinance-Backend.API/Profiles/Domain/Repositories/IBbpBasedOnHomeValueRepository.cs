using TecFinance_Backend.API.Profiles.Domain.Models;

namespace TecFinance_Backend.API.Profiles.Domain.Repositories;

public interface IBbpBasedOnHomeValueRepository
{
    Task<IEnumerable<BbpBasedOnHomeValue>> ListAsync();
    Task<BbpBasedOnHomeValue> FindByIdAsync(int bbpId);
    Task AddAsync(BbpBasedOnHomeValue bank);
    void Update(BbpBasedOnHomeValue bank);
    void Remove(BbpBasedOnHomeValue bank);
}