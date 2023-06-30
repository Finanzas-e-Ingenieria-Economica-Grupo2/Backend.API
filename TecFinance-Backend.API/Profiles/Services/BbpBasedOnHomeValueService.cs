using TecFinance_Backend.API.Profiles.Domain.Models;
using TecFinance_Backend.API.Profiles.Domain.Repositories;
using TecFinance_Backend.API.Profiles.Domain.Services;
using TecFinance_Backend.API.Profiles.Domain.Services.Communication;
using TecFinance_Backend.API.Shared.Domain.Repositories;

namespace TecFinance_Backend.API.Profiles.Services;

public class BbpBasedOnHomeValueService : IBbpBasedOnHomeValueService
{
    private readonly IBbpBasedOnHomeValueRepository _bbpBasedOnHomeValueRepository;
    private readonly IBankRepository _bankRepository;
    private readonly IUnitOfWork _unitOfWork;


    public BbpBasedOnHomeValueService(IBbpBasedOnHomeValueRepository bbpBasedOnHomeValueRepository, IBankRepository bankRepository, IUnitOfWork unitOfWork)
    {
        _bbpBasedOnHomeValueRepository = bbpBasedOnHomeValueRepository;
        _bankRepository = bankRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<BbpBasedOnHomeValue>> ListAsync()
    {
        return await _bbpBasedOnHomeValueRepository.ListAsync();
    }

    public async Task<BbpBasedOnHomeValue> FindByBankIdAsync(int bankId)
    {
        return await _bbpBasedOnHomeValueRepository.FindByBankIdAsync(bankId);
    }

    public async Task<BbpBasedOnHomeValueResponse> SaveAsync(BbpBasedOnHomeValue bbp)
    {
        // Validate if BankId already exist

        var existingBankWithId = await _bankRepository.FindByIdAsync(bbp.BankId);
        
        if (existingBankWithId == null)
            return new BbpBasedOnHomeValueResponse("This bank id doesn't exist.");
        
        try
        {
            await _bbpBasedOnHomeValueRepository.AddAsync(bbp);
            await _unitOfWork.CompleteAsync();
            
            return new BbpBasedOnHomeValueResponse(bbp);
        }
        catch (Exception e)
        {
            // Do some logging stuff
            return new BbpBasedOnHomeValueResponse($"An error occurred while saving the bbp array: {e.Message}");
        }

    }
}