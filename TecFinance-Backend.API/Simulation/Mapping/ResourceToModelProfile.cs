using AutoMapper;
using TecFinance_Backend.API.Simulation.Domain.Models;
using TecFinance_Backend.API.Simulation.Resources;

namespace TecFinance_Backend.API.Simulation.Mapping;

public class ResourceToModelProfile: Profile
{
    public ResourceToModelProfile()
    {
        CreateMap<SavePaymentResource, Payment>();
        CreateMap<SaveOfferResource, Offer>();
        CreateMap<SaveConfigurationResource, Configuration>();
    }
}