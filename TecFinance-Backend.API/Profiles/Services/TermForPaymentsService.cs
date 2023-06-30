using TecFinance_Backend.API.Profiles.Domain.Models;
using TecFinance_Backend.API.Profiles.Domain.Repositories;
using TecFinance_Backend.API.Profiles.Domain.Services;
using TecFinance_Backend.API.Profiles.Domain.Services.Communication;
using TecFinance_Backend.API.Profiles.Persistence.Repositories;
using TecFinance_Backend.API.Shared.Domain.Repositories;

namespace TecFinance_Backend.API.Profiles.Services;

public class TermForPaymentsService : ITermForPaymentsService
{
    private readonly ITermForPaymentsRepository _termForPaymentsRepository;
    private readonly IBankRepository _bankRepository;
    private readonly IUnitOfWork _unitOfWork;
    
    public TermForPaymentsService(ITermForPaymentsRepository termForPaymentsRepository, IBankRepository bankRepository, IUnitOfWork unitOfWork)
    {
        _termForPaymentsRepository = termForPaymentsRepository;
        _bankRepository = bankRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<TermForPayments>> ListAsync()
    {
        return await _termForPaymentsRepository.ListAsync();
    }

    public async Task<TermForPayments> FindByBankIdAsync(int bankId)
    {
        return await _termForPaymentsRepository.FindByBankIdAsync(bankId);
    }

    public async Task<TermForPaymentsResponse> SaveAsync(TermForPayments term)
    {
        // Validate if BankId already exist

        var existingBankWithId = await _bankRepository.FindByIdAsync(term.BankId);
        
        if (existingBankWithId == null)
            return new TermForPaymentsResponse("This bank id doesn't exist.");
        
        try
        {
            await _termForPaymentsRepository.AddAsync(term);
            await _unitOfWork.CompleteAsync();
            
            return new TermForPaymentsResponse(term);
        }
        catch (Exception e)
        {
            // Do some logging stuff
            return new TermForPaymentsResponse($"An error occurred while saving the term for payments: {e.Message}");
        }
    }
}