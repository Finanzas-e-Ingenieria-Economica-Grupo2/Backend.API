using TecFinance_Backend.API.Profiles.Domain.Models;
using TecFinance_Backend.API.Profiles.Domain.Services.Communication;

namespace TecFinance_Backend.API.Profiles.Domain.Services;

public interface ITermForPaymentsService
{
    Task<IEnumerable<TermForPayments>> ListAsync();
    Task<TermForPayments> FindByBankIdAsync(int bankId);
    Task<TermForPaymentsResponse> SaveAsync(TermForPayments term);
    //Task<TermForPaymentsResponse> UpdateAsync(int id, TermForPayments term);
    //Task<TermForPaymentsResponse> DeleteAsync(int id);
}