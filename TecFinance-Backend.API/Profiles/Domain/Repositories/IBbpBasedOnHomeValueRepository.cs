using TecFinance_Backend.API.Profiles.Domain.Models;

namespace TecFinance_Backend.API.Profiles.Domain.Repositories;

public interface IBbpBasedOnHomeValueRepository
{
    Task<IEnumerable<BbpBasedOnHomeValue>> ListAsync();
    Task<BbpBasedOnHomeValue> FindByIdAsync(int bbpId);
    Task<BbpBasedOnHomeValue> FindByBankIdAsync(int bankId);
    Task AddAsync(BbpBasedOnHomeValue bbp);
    void Update(BbpBasedOnHomeValue bbp);
    void Remove(BbpBasedOnHomeValue bbp);
}