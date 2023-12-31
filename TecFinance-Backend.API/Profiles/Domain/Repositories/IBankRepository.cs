﻿using TecFinance_Backend.API.Profiles.Domain.Models;

namespace TecFinance_Backend.API.Profiles.Domain.Repositories;

public interface IBankRepository
{
    Task<IEnumerable<Bank>> ListAsync();
    Task<Bank> FindByIdAsync(int bankId);
    Task<Bank> FindByNameAsync(string name);
    Task AddAsync(Bank bank);
    void Update(Bank bank);
    void Remove(Bank bank);
}