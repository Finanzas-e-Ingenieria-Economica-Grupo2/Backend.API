using TecFinance_Backend.API.Profiles.Domain.Models;
using TecFinance_Backend.API.Profiles.Domain.Services.Communication;

namespace TecFinance_Backend.API.Profiles.Domain.Services;

public interface IBankService
{
    Task<IEnumerable<Bank>> ListAsync();
    Task<Bank> FindByNameAsync(string name);
    Task<BankResponse> SaveAsync(Bank bank);
    Task<BankResponse> UpdateAsync(int id, Bank bank);
    Task<BankResponse> DeleteAsync(int id);
}