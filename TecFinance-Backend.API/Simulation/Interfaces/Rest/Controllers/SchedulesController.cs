using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TecFinance_Backend.API.Shared.Extensions;
using TecFinance_Backend.API.Simulation.Domain.Models;
using TecFinance_Backend.API.Simulation.Domain.Services;
using TecFinance_Backend.API.Simulation.Resources;

namespace TecFinance_Backend.API.Simulation.Interfaces.Rest.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class SchedulesController : ControllerBase
{
    private readonly IScheduleService _scheduleService;
    private readonly IMapper _mapper;

    public SchedulesController(IScheduleService scheduleService, IMapper mapper)
    {
        _scheduleService = scheduleService;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<IEnumerable<ScheduleResource>> GetAllAsync()
    {
        var schedules = await _scheduleService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Schedule>, IEnumerable<ScheduleResource>>(schedules);
        return resources;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveScheduleResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var schedule = _mapper.Map<SaveScheduleResource, Schedule>(resource);
        
        var result = await _scheduleService.SaveAsync(schedule);
        
        if (!result.Success)
            return BadRequest(result.Message);
        
        var scheduleResource = _mapper.Map<Schedule, ScheduleResource>(result.Resource);

        return Created(nameof(PostAsync), scheduleResource);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _scheduleService.DeleteAsync(id);

        if (!result.Success)
            return BadRequest(result.Message);

        var scheduleResource = _mapper.Map<Schedule, ScheduleResource>(result.Resource);
        return Ok(scheduleResource);
    }
}