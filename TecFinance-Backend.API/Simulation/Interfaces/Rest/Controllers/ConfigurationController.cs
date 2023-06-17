using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TecFinance_Backend.API.Shared.Extensions;
using TecFinance_Backend.API.Simulation.Domain.Models;
using TecFinance_Backend.API.Simulation.Domain.Services;
using TecFinance_Backend.API.Simulation.Resources;

namespace TecFinance_Backend.API.Simulation.Interfaces.Rest.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class ConfigurationController : ControllerBase
{
    private readonly IConfigurationService _configurationService;
    private readonly IMapper _mapper;

    public ConfigurationController(IConfigurationService configurationService, IMapper mapper)
    {
        _configurationService = configurationService;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<IEnumerable<ConfigurationResource>> GetAllAsync()
    {
        var configurations = await _configurationService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Configuration>, IEnumerable<ConfigurationResource>>(configurations);
        return resources;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveConfigurationResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var configuration = _mapper.Map<SaveConfigurationResource, Configuration>(resource);
        
        var result = await _configurationService.SaveAsync(configuration);
        
        if (!result.Success)
            return BadRequest(result.Message);
        
        var configurationResource = _mapper.Map<Configuration, ConfigurationResource>(result.Resource);

        return Created(nameof(PostAsync), configurationResource);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveConfigurationResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var configuration = _mapper.Map<SaveConfigurationResource, Configuration>(resource);
        var result = await _configurationService.UpdateAsync(id, configuration);

        if (!result.Success)
            return BadRequest(result.Message);

        var configurationResource = _mapper.Map<Configuration, ConfigurationResource>(result.Resource);
        return Ok(configurationResource);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _configurationService.DeleteAsync(id);

        if (!result.Success)
            return BadRequest(result.Message);

        var configurationResource = _mapper.Map<Configuration, ConfigurationResource>(result.Resource);
        return Ok(configurationResource);
    }
}