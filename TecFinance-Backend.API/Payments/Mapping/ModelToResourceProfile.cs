using AutoMapper;
using TecFinance_Backend.API.Payments.Domain.Models;
using TecFinance_Backend.API.Payments.Resources;

namespace TecFinance_Backend.API.Payments.Mapping;

public class ModelToResourceProfile: Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<Payment, PaymentResource>();
        CreateMap<Schedule, ScheduleResource>();
    }
}