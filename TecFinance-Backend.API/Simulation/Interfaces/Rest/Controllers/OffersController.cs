using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TecFinance_Backend.API.Shared.Extensions;
using TecFinance_Backend.API.Simulation.Domain.Models;
using TecFinance_Backend.API.Simulation.Domain.Services;
using TecFinance_Backend.API.Simulation.Resources;

namespace TecFinance_Backend.API.Simulation.Interfaces.Rest.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class OffersController : ControllerBase
{
    private readonly IOfferService _offerService;
    private readonly IMapper _mapper;

    public OffersController(IOfferService offerService, IMapper mapper)
    {
        _offerService = offerService;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<IEnumerable<OfferResource>> GetAllAsync()
    {
        var schedules = await _offerService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Offer>, IEnumerable<OfferResource>>(schedules);
        return resources;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveOfferResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var offer = _mapper.Map<SaveOfferResource, Offer>(resource);
        
        var result = await _offerService.SaveAsync(offer);
        
        if (!result.Success)
            return BadRequest(result.Message);
        
        var offerResource = _mapper.Map<Offer, OfferResource>(result.Resource);

        return Created(nameof(PostAsync), offerResource);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _offerService.DeleteAsync(id);

        if (!result.Success)
            return BadRequest(result.Message);

        var offerResource = _mapper.Map<Offer, OfferResource>(result.Resource);
        return Ok(offerResource);
    }
}