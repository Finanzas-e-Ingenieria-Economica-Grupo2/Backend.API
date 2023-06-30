using TecFinance_Backend.API.Profiles.Domain.Models;
using TecFinance_Backend.API.Profiles.Domain.Repositories;
using TecFinance_Backend.API.Profiles.Domain.Services;
using TecFinance_Backend.API.Profiles.Domain.Services.Communication;
using TecFinance_Backend.API.Shared.Domain.Repositories;

namespace TecFinance_Backend.API.Profiles.Services;

public class BankService : IBankService
{
    private readonly IBankRepository _bankRepository;
    private readonly IUnitOfWork _unitOfWork;

    public BankService(IBankRepository bankRepository, IUnitOfWork unitOfWork)
    {
        _bankRepository = bankRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Bank>> ListAsync()
    {
        return await _bankRepository.ListAsync();
    }

    public async Task<Bank> FindByNameAsync(string name)
    {
        return await _bankRepository.FindByNameAsync(name);
    }

    public async Task<BankResponse> SaveAsync(Bank bank)
    {
        // Validate if Name is already used
        
        var existingBankWithName = await _bankRepository.FindByNameAsync(bank.Name);
        
        if (existingBankWithName != null)
            return new BankResponse("Name is already used.");
        
        // Perform adding
        
        try
        {
            await _bankRepository.AddAsync(bank);
            await _unitOfWork.CompleteAsync();
            
            return new BankResponse(bank);
        }
        catch (Exception e)
        {
            // Do some logging stuff
            return new BankResponse($"An error occurred while saving the bank: {e.Message}");
        }
    }

    public async Task<BankResponse> UpdateAsync(int id, Bank bank)
    {
        // Validate if bank exists

        var existingBank = await _bankRepository.FindByIdAsync(id);

        if (existingBank == null)
            return new BankResponse("Bank not found.");

        // Validate if Name is already used
        
        var existingBankWithName = await _bankRepository.FindByNameAsync(bank.Name);
        
        if (existingBankWithName != null && existingBankWithName.Id != id)
            return new BankResponse("Name is already used.");
        
        // Modify fields
        
        existingBank.Name = bank.Name;
        existingBank.MinimumLoan = bank.MinimumLoan;
        existingBank.MaximumLoan = bank.MaximumLoan;
        //existingBank.BbpBasedOnHomeValue = bank.BbpBasedOnHomeValue;
        //existingBank.InitialFeeBasedOnHomeValue = bank.InitialFeeBasedOnHomeValue;
        existingBank.LienInsurance = bank.LienInsurance;
        existingBank.PropertyInsurance = bank.PropertyInsurance;
        existingBank.AppraisalExpenses = bank.AppraisalExpenses;
        //existingBank.TermForPayments = bank.TermForPayments;

        // Perform update
        
        try
        {
            _bankRepository.Update(existingBank);
            await _unitOfWork.CompleteAsync();
            
            return new BankResponse(existingBank);
        }
        catch (Exception e)
        {
            // Error handling
            return new BankResponse($"An error occurred while updating the bank: {e.Message}");
        }
    }

    public async Task<BankResponse> DeleteAsync(int id)
    {
        // Validate if bank exists
        
        var existingBank = await _bankRepository.FindByIdAsync(id);
        
        if (existingBank == null)
            return new BankResponse("Bank not found.");
        
        // Perform delete
        
        try
        {
            _bankRepository.Remove(existingBank);
            await _unitOfWork.CompleteAsync();
            
            return new BankResponse(existingBank);
        }
        catch (Exception e)
        {
            // Error handling
            return new BankResponse($"An error occurred while deleting the bank: {e.Message}");
        }
    }
}