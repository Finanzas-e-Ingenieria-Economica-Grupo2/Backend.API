using TecFinance_Backend.API.Shared.Domain.Repositories;
using TecFinance_Backend.API.Simulation.Domain.Models;
using TecFinance_Backend.API.Simulation.Domain.Repositories;
using TecFinance_Backend.API.Simulation.Domain.Services;
using TecFinance_Backend.API.Simulation.Domain.Services.Communication;

namespace TecFinance_Backend.API.Simulation.Services;

public class OfferService : IOfferService
{
    private readonly IOfferRepository _offerRepository;
    private readonly IUnitOfWork _unitOfWork;

    public OfferService(IOfferRepository offerRepository, IUnitOfWork unitOfWork)
    {
        _offerRepository = offerRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Offer>> ListAsync()
    {
        return await _offerRepository.ListAsync();
    }

    public async Task<OfferResponse> SaveAsync(Offer offer)
    {
        // Validate existence of assigned schedule
        

        // Perform adding
        
        try
        {
            await _offerRepository.AddAsync(offer);
            await _unitOfWork.CompleteAsync();
            
            return new OfferResponse(offer);
        }
        catch (Exception e)
        {
            // Do some logging stuff
            return new OfferResponse($"An error occurred while saving the schedule: {e.Message}");
        }    
    }

    public async Task<OfferResponse> UpdateAsync(int id, Offer offer)
    {
        // Validate if schedule exists

        var existingSchedule = await _offerRepository.FindByIdAsync(id);

        if (existingSchedule == null)
            return new OfferResponse("Schedule not found.");

        // Modify fields
        
        existingSchedule.Payments = offer.Payments;
        
        // Perform update
        
        try
        {
            _offerRepository.Update(existingSchedule);
            await _unitOfWork.CompleteAsync();
            
            return new OfferResponse(existingSchedule);
        }
        catch (Exception e)
        {
            // Error handling
            return new OfferResponse($"An error occurred while updating the schedule: {e.Message}");
        }
    }

    public async Task<OfferResponse> DeleteAsync(int id)
    {
        // Validate if schedule exists
        
        var existingSchedule = await _offerRepository.FindByIdAsync(id);
        
        if (existingSchedule == null)
            return new OfferResponse("Schedule not found.");
        
        // Perform delete
        
        try
        {
            _offerRepository.Remove(existingSchedule);
            await _unitOfWork.CompleteAsync();
            
            return new OfferResponse(existingSchedule);
        }
        catch (Exception e)
        {
            // Error handling
            return new OfferResponse($"An error occurred while deleting the payment: {e.Message}");
        }
    }
}