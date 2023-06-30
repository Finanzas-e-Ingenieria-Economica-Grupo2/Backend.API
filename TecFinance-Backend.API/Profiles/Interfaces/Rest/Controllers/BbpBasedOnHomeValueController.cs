using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TecFinance_Backend.API.Profiles.Domain.Models;
using TecFinance_Backend.API.Profiles.Domain.Services;
using TecFinance_Backend.API.Profiles.Resources;
using TecFinance_Backend.API.Shared.Extensions;

namespace TecFinance_Backend.API.Profiles.Interfaces.Rest.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class BbpBasedOnHomeValueController : ControllerBase
{
    private readonly IBbpBasedOnHomeValueService _bbpBasedOnHomeValueService;
    private readonly IMapper _mapper;

    public BbpBasedOnHomeValueController(IBbpBasedOnHomeValueService bbpBasedOnHomeValueService, IMapper mapper)
    {
        _bbpBasedOnHomeValueService = bbpBasedOnHomeValueService;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<IEnumerable<BbpBasedOnHomeValueResource>> GetAllAsync()
    {
        var bbps = await _bbpBasedOnHomeValueService.ListAsync();
        var resources = _mapper.Map<IEnumerable<BbpBasedOnHomeValue>, IEnumerable<BbpBasedOnHomeValueResource>>(bbps);
        return resources;
    }
    
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveBbpBasedOnHomeValueResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var bbp = _mapper.Map<SaveBbpBasedOnHomeValueResource, BbpBasedOnHomeValue>(resource);
        
        var result = await _bbpBasedOnHomeValueService.SaveAsync(bbp);
        
        if (!result.Success)
            return BadRequest(result.Message);
        
        var bbpResource = _mapper.Map<BbpBasedOnHomeValue, BbpBasedOnHomeValueResource>(result.Resource);

        return Created(nameof(PostAsync), bbpResource);
    }
}