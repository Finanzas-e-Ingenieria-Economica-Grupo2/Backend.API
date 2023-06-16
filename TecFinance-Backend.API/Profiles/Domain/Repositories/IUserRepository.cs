using TecFinance_Backend.API.Profiles.Domain.Models;

namespace TecFinance_Backend.API.Profiles.Domain.Repositories;

public interface IUserRepository
{
    Task<IEnumerable<User>> ListAsync();
    Task<User> FindByIdAsync(int userId);
    Task<User> FindByEmailAsync(string email);
    Task AddAsync(User user);
    void Update(User user);
    void Remove(User user);
}