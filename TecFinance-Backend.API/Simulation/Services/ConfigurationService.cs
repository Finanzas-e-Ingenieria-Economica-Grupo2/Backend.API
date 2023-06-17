using TecFinance_Backend.API.Shared.Domain.Repositories;
using TecFinance_Backend.API.Simulation.Domain.Models;
using TecFinance_Backend.API.Simulation.Domain.Repositories;
using TecFinance_Backend.API.Simulation.Domain.Services;
using TecFinance_Backend.API.Simulation.Domain.Services.Communication;

namespace TecFinance_Backend.API.Simulation.Services;

public class ConfigurationService : IConfigurationService
{
    private readonly IConfigurationRepository _configurationRepository;
    private readonly IOfferRepository _offerRepository;
    private readonly IUnitOfWork _unitOfWork;
    
    public ConfigurationService(IConfigurationRepository configurationRepository, IOfferRepository offerRepository, IUnitOfWork unitOfWork)
    {
        _configurationRepository = configurationRepository;
        _offerRepository = offerRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Configuration>> ListAsync()
    {
        return await _configurationRepository.ListAsync();
    }

    public async Task<ConfigurationResponse> SaveAsync(Configuration configuration)
    {
        // Validate existence of assigned offer
        
        var existingOffer = await _offerRepository.FindByIdAsync(configuration.OfferId);
        
        if (existingOffer == null)
            return new ConfigurationResponse("Invalid offer.");

        // Perform adding
        
        try
        {
            await _configurationRepository.AddAsync(configuration);
            await _unitOfWork.CompleteAsync();
            
            return new ConfigurationResponse(configuration);
        }
        catch (Exception e)
        {
            // Do some logging stuff
            return new ConfigurationResponse($"An error occurred while saving the tutorial: {e.Message}");
        }
    }

    public async Task<ConfigurationResponse> UpdateAsync(int configurationId, Configuration configuration)
    {
        // Validate if configuration exists

        var existingConfiguration = await _configurationRepository.FindByIdAsync(configurationId);

        if (existingConfiguration == null)
            return new ConfigurationResponse("Configuration not found.");
        
        // Validate existence of assigned offer
        
        var existingOffer = await _offerRepository.FindByIdAsync(configuration.OfferId);
        
        if (existingOffer == null)
            return new ConfigurationResponse("Invalid offer.");
        
        // Validate there aren't more than one configuration for an specific offer
        
        var existingConfigurationWithOffer = await _configurationRepository.FindByOfferIdAsync(configuration.OfferId);
        
        if (existingConfigurationWithOffer != null && existingConfigurationWithOffer.Id != configurationId)
            return new ConfigurationResponse("This offer already have a configuration.");
        
        // Modify fields
        
        existingConfiguration.InterestRateType = configuration.InterestRateType;
        existingConfiguration.Currency = configuration.Currency;
        existingConfiguration.AmountTotalGracePeriod = configuration.AmountTotalGracePeriod;
        existingConfiguration.AmountPartialGracePeriod = configuration.AmountPartialGracePeriod;
        existingConfiguration.AmountPartialGracePeriod = configuration.AmountPartialGracePeriod;
        existingConfiguration.OfferId = configuration.OfferId;
        existingConfiguration.Offer = configuration.Offer;

        // Perform update
        
        try
        {
            _configurationRepository.Update(existingConfiguration);
            await _unitOfWork.CompleteAsync();
            
            return new ConfigurationResponse(existingConfiguration);
        }
        catch (Exception e)
        {
            // Error handling
            return new ConfigurationResponse($"An error occurred while updating the configuration: {e.Message}");
        }
    }

    public async Task<ConfigurationResponse> DeleteAsync(int configurationId)
    {
        // Validate if tutorials exists
        
        var existingConfiguration = await _configurationRepository.FindByIdAsync(configurationId);
        
        if (existingConfiguration == null)
            return new ConfigurationResponse("Configuration not found.");
        
        // Perform delete
        
        try
        {
            _configurationRepository.Remove(existingConfiguration);
            await _unitOfWork.CompleteAsync();
            
            return new ConfigurationResponse(existingConfiguration);
        }
        catch (Exception e)
        {
            // Error handling
            return new ConfigurationResponse($"An error occurred while deleting the configuration: {e.Message}");
        }
    }
}