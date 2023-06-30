using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TecFinance_Backend.API.Profiles.Domain.Models;
using TecFinance_Backend.API.Profiles.Domain.Services;
using TecFinance_Backend.API.Profiles.Resources;
using TecFinance_Backend.API.Shared.Extensions;

namespace TecFinance_Backend.API.Profiles.Interfaces.Rest.Controllers;

public class TermForPaymentsController : ControllerBase
{
    private readonly ITermForPaymentsService _termForPaymentsService;
    private readonly IMapper _mapper;

    public TermForPaymentsController(ITermForPaymentsService termForPaymentsService, IMapper mapper)
    {
        _termForPaymentsService = termForPaymentsService;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<IEnumerable<TermForPaymentsResource>> GetAllAsync()
    {
        var terms = await _termForPaymentsService.ListAsync();
        var resources = _mapper.Map<IEnumerable<TermForPayments>, IEnumerable<TermForPaymentsResource>>(terms);
        return resources;
    }
    
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveTermForPaymentsResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var term = _mapper.Map<SaveTermForPaymentsResource, TermForPayments>(resource);
        
        var result = await _termForPaymentsService.SaveAsync(term);
        
        if (!result.Success)
            return BadRequest(result.Message);
        
        var termResource = _mapper.Map<TermForPayments, TermForPaymentsResource>(result.Resource);

        return Created(nameof(PostAsync), termResource);
    }
}