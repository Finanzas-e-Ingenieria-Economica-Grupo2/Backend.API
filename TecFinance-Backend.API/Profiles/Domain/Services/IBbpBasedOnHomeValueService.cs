using TecFinance_Backend.API.Profiles.Domain.Models;
using TecFinance_Backend.API.Profiles.Domain.Services.Communication;

namespace TecFinance_Backend.API.Profiles.Domain.Services;

public interface IBbpBasedOnHomeValueService
{
    Task<IEnumerable<BbpBasedOnHomeValue>> ListAsync();
    Task<BbpBasedOnHomeValueResponse> SaveAsync(BbpBasedOnHomeValue bbp);
    Task<BbpBasedOnHomeValueResponse> UpdateAsync(int id, BbpBasedOnHomeValue bbp);
    Task<BbpBasedOnHomeValueResponse> DeleteAsync(int id);
}