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
        // Validate existence of assigned user
        // Validate existence of assigned bank
        // Validate existence of assigned configuration

        

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
            return new OfferResponse($"An error occurred while saving the offer: {e.Message}");
        }    
    }

    public async Task<OfferResponse> UpdateAsync(int id, Offer offer)
    {
        // Validate if offer exists

        var existingOffer = await _offerRepository.FindByIdAsync(id);

        if (existingOffer == null)
            return new OfferResponse("Offer not found.");

        // Modify fields
        
        existingOffer.HomeValue = offer.HomeValue;
        existingOffer.AmountToFinance = offer.AmountToFinance;
        existingOffer.IsHousingSupport = offer.IsHousingSupport;
        existingOffer.IsHousingSustainable = offer.IsHousingSustainable;
        existingOffer.Tea = offer.Tea;
        existingOffer.Tna = offer.Tna;
        existingOffer.Capitalization = offer.Capitalization;
        existingOffer.TermInMonths = offer.TermInMonths;
        existingOffer.Tcea = offer.Tcea;
        existingOffer.Van = offer.Van;
        existingOffer.Tir = offer.Tir;
        
        existingOffer.Payments = offer.Payments;
        
        // Perform update
        
        try
        {
            _offerRepository.Update(existingOffer);
            await _unitOfWork.CompleteAsync();
            
            return new OfferResponse(existingOffer);
        }
        catch (Exception e)
        {
            // Error handling
            return new OfferResponse($"An error occurred while updating the offer: {e.Message}");
        }
    }

    public async Task<OfferResponse> DeleteAsync(int id)
    {
        // Validate if offer exists
        
        var existingOffer = await _offerRepository.FindByIdAsync(id);
        
        if (existingOffer == null)
            return new OfferResponse("Offer not found.");
        
        // Perform delete
        
        try
        {
            _offerRepository.Remove(existingOffer);
            await _unitOfWork.CompleteAsync();
            
            return new OfferResponse(existingOffer);
        }
        catch (Exception e)
        {
            // Error handling
            return new OfferResponse($"An error occurred while deleting the offer: {e.Message}");
        }
    }
}