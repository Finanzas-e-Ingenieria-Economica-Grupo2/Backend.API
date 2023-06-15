using TecFinance_Backend.API.Profiles.Domain.Models;

namespace TecFinance_Backend.API.Profiles.Domain.Repositories;

public interface IBankRepository
{
    Task<IEnumerable<Bank>> ListAsync();
    Task<Bank> FindByIdAsync(int id);
    Task AddAsync(Bank bank);
    void Update(Bank bank);
    void Remove(Bank bank);
}