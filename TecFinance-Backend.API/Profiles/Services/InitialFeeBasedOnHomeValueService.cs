using TecFinance_Backend.API.Profiles.Domain.Models;
using TecFinance_Backend.API.Profiles.Domain.Repositories;
using TecFinance_Backend.API.Profiles.Domain.Services;
using TecFinance_Backend.API.Profiles.Domain.Services.Communication;
using TecFinance_Backend.API.Profiles.Persistence.Repositories;
using TecFinance_Backend.API.Shared.Domain.Repositories;

namespace TecFinance_Backend.API.Profiles.Services;

public class InitialFeeBasedOnHomeValueService : IInitialFeeBasedOnHomeValueService
{
    private readonly IInitialFeeBasedOnHomeValueRepository _initialFeeBasedOnHomeValueRepository;
    private readonly IBankRepository _bankRepository;
    private readonly IUnitOfWork _unitOfWork;

    public InitialFeeBasedOnHomeValueService(IInitialFeeBasedOnHomeValueRepository initialFeeBasedOnHomeValueRepository, IBankRepository bankRepository, IUnitOfWork unitOfWork)
    {
        _initialFeeBasedOnHomeValueRepository = initialFeeBasedOnHomeValueRepository;
        _bankRepository = bankRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<InitialFeeBasedOnHomeValue>> ListAsync()
    {
        return await _initialFeeBasedOnHomeValueRepository.ListAsync();
    }

    public async Task<InitialFeeBasedOnHomeValue> FindByBankIdAsync(int bankId)
    {
        return await _initialFeeBasedOnHomeValueRepository.FindByBankIdAsync(bankId);
    }

    public async Task<InitialFeeBasedOnHomeValueResponse> SaveAsync(InitialFeeBasedOnHomeValue initial)
    {
        // Validate if BankId already exist

        var existingBankWithId = await _bankRepository.FindByIdAsync(initial.BankId);
        
        if (existingBankWithId == null)
            return new InitialFeeBasedOnHomeValueResponse("This bank id doesn't exist.");
        
        try
        {
            await _initialFeeBasedOnHomeValueRepository.AddAsync(initial);
            await _unitOfWork.CompleteAsync();
            
            return new InitialFeeBasedOnHomeValueResponse(initial);
        }
        catch (Exception e)
        {
            // Do some logging stuff
            return new InitialFeeBasedOnHomeValueResponse($"An error occurred while saving the initial fee array: {e.Message}");
        }
    }
}