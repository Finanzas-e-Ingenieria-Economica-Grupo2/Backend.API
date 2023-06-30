using TecFinance_Backend.API.Profiles.Domain.Models;

namespace TecFinance_Backend.API.Profiles.Domain.Repositories;

public interface IInitialFeeBasedOnHomeValueRepository
{
    Task<IEnumerable<InitialFeeBasedOnHomeValue>> ListAsync();
    Task<InitialFeeBasedOnHomeValue> FindByIdAsync(int initialId);
    Task<InitialFeeBasedOnHomeValue> FindByBankIdAsync(int bankId);
    Task AddAsync(InitialFeeBasedOnHomeValue initialFee);
    void Update(InitialFeeBasedOnHomeValue initialFee);
    void Remove(InitialFeeBasedOnHomeValue initialFee);
}