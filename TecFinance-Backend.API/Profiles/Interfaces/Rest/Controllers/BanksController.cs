using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TecFinance_Backend.API.Profiles.Domain.Models;
using TecFinance_Backend.API.Profiles.Domain.Services;
using TecFinance_Backend.API.Profiles.Resources;
using TecFinance_Backend.API.Shared.Extensions;

namespace TecFinance_Backend.API.Profiles.Interfaces.Rest.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class BanksController : ControllerBase
{
    private readonly IBankService _bankService;
    private readonly IMapper _mapper;
    
    public BanksController(IBankService bankService, IMapper mapper)
    {
        _bankService = bankService;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<IEnumerable<BankResource>> GetAllAsync()
    {
        var banks = await _bankService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Bank>, IEnumerable<BankResource>>(banks);
        return resources;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveBankResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var bank = _mapper.Map<SaveBankResource, Bank>(resource);
        
        var result = await _bankService.SaveAsync(bank);
        
        if (!result.Success)
            return BadRequest(result.Message);
        
        var bankResource = _mapper.Map<Bank, BankResource>(result.Resource);

        return Created(nameof(PostAsync), bankResource);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveBankResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var bank = _mapper.Map<SaveBankResource, Bank>(resource);
        var result = await _bankService.UpdateAsync(id, bank);

        if (!result.Success)
            return BadRequest(result.Message);

        var bankResource = _mapper.Map<Bank, BankResource>(result.Resource);
        return Ok(bankResource);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _bankService.DeleteAsync(id);

        if (!result.Success)
            return BadRequest(result.Message);

        var bankResource = _mapper.Map<Bank, BankResource>(result.Resource);
        return Ok(bankResource);
    }
}