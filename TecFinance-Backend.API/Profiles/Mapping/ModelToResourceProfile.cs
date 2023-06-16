﻿using AutoMapper;
using TecFinance_Backend.API.Profiles.Domain.Models;
using TecFinance_Backend.API.Profiles.Resources;

namespace TecFinance_Backend.API.Profiles.Mapping;

public class ModelToResourceProfile : Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<User, UserResource>();
        CreateMap<Bank, BankResource>();
    }
}