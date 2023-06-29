using TecFinance_Backend.API.Profiles.Domain.Models;
using TecFinance_Backend.API.Profiles.Domain.Services.Communication;

namespace TecFinance_Backend.API.Profiles.Domain.Services;

public interface IInitialFeeBasedOnHomeValueService
{
    Task<IEnumerable<InitialFeeBasedOnHomeValue>> ListAsync();
    Task<InitialFeeBasedOnHomeValueResponse> SaveAsync(InitialFeeBasedOnHomeValue initial);
    Task<InitialFeeBasedOnHomeValueResponse> UpdateAsync(int id, InitialFeeBasedOnHomeValue initial);
    Task<InitialFeeBasedOnHomeValueResponse> DeleteAsync(int id);
}