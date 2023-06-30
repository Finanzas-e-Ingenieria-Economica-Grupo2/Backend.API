using TecFinance_Backend.API.Profiles.Domain.Models;

namespace TecFinance_Backend.API.Profiles.Domain.Repositories;

public interface ITermForPaymentsRepository
{
    Task<IEnumerable<TermForPayments>> ListAsync();
    Task<TermForPayments> FindByIdAsync(int termId);
    Task<TermForPayments> FindByBankIdAsync(int bankId);
    Task AddAsync(TermForPayments term);
    void Update(TermForPayments term);
    void Remove(TermForPayments term);
}