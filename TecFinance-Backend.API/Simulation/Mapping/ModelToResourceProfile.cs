using AutoMapper;
using TecFinance_Backend.API.Simulation.Domain.Models;
using TecFinance_Backend.API.Simulation.Resources;

namespace TecFinance_Backend.API.Simulation.Mapping;

public class ModelToResourceProfile: Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<Payment, PaymentResource>();
        CreateMap<Schedule, ScheduleResource>();
    }
}