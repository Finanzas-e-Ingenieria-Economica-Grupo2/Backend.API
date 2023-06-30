using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TecFinance_Backend.API.Profiles.Domain.Models;
using TecFinance_Backend.API.Profiles.Domain.Services;
using TecFinance_Backend.API.Profiles.Resources;
using TecFinance_Backend.API.Shared.Extensions;

namespace TecFinance_Backend.API.Profiles.Interfaces.Rest.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class InitialFeeBasedOnHomeValueController : ControllerBase
{
    private readonly IInitialFeeBasedOnHomeValueService _initialFeeBasedOnHomeValueService;
    private readonly IMapper _mapper;

    public InitialFeeBasedOnHomeValueController(IInitialFeeBasedOnHomeValueService initialFeeBasedOnHomeValueService, IMapper mapper)
    {
        _initialFeeBasedOnHomeValueService = initialFeeBasedOnHomeValueService;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<IEnumerable<InitialFeeBasedOnHomeValueResource>> GetAllAsync()
    {
        var initialFees = await _initialFeeBasedOnHomeValueService.ListAsync();
        var resources = _mapper.Map<IEnumerable<InitialFeeBasedOnHomeValue>, IEnumerable<InitialFeeBasedOnHomeValueResource>>(initialFees);
        return resources;
    }
    
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveInitialFeeBasedOnHomeValueResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var initialFee = _mapper.Map<SaveInitialFeeBasedOnHomeValueResource, InitialFeeBasedOnHomeValue>(resource);
        
        var result = await _initialFeeBasedOnHomeValueService.SaveAsync(initialFee);
        
        if (!result.Success)
            return BadRequest(result.Message);
        
        var initialResource = _mapper.Map<InitialFeeBasedOnHomeValue, InitialFeeBasedOnHomeValueResource>(result.Resource);

        return Created(nameof(PostAsync), initialResource);
    }
}