using AutoMapper;
using TecFinance_Backend.API.Payments.Domain.Models;
using TecFinance_Backend.API.Payments.Resources;

namespace TecFinance_Backend.API.Payments.Mapping;

public class ResourceToModelProfile: Profile
{
    public ResourceToModelProfile()
    {
        CreateMap<SavePaymentResource, Payment>();
        CreateMap<SaveScheduleResource, Schedule>();
    }
}