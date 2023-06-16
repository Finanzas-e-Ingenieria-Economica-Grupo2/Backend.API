using TecFinance_Backend.API.Shared.Domain.Repositories;
using TecFinance_Backend.API.Simulation.Domain.Models;
using TecFinance_Backend.API.Simulation.Domain.Repositories;
using TecFinance_Backend.API.Simulation.Domain.Services;
using TecFinance_Backend.API.Simulation.Domain.Services.Communication;

namespace TecFinance_Backend.API.Simulation.Services;

public class ScheduleService : IScheduleService
{
    private readonly IScheduleRepository _scheduleRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ScheduleService(IScheduleRepository scheduleRepository, IUnitOfWork unitOfWork)
    {
        _scheduleRepository = scheduleRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Schedule>> ListAsync()
    {
        return await _scheduleRepository.ListAsync();
    }

    public async Task<ScheduleResponse> SaveAsync(Schedule schedule)
    {
        // Validate existence of assigned schedule
        

        // Perform adding
        
        try
        {
            await _scheduleRepository.AddAsync(schedule);
            await _unitOfWork.CompleteAsync();
            
            return new ScheduleResponse(schedule);
        }
        catch (Exception e)
        {
            // Do some logging stuff
            return new ScheduleResponse($"An error occurred while saving the schedule: {e.Message}");
        }    
    }

    public async Task<ScheduleResponse> UpdateAsync(int id, Schedule schedule)
    {
        // Validate if schedule exists

        var existingSchedule = await _scheduleRepository.FindByIdAsync(id);

        if (existingSchedule == null)
            return new ScheduleResponse("Schedule not found.");

        // Modify fields
        
        existingSchedule.Payments = schedule.Payments;
        
        // Perform update
        
        try
        {
            _scheduleRepository.Update(existingSchedule);
            await _unitOfWork.CompleteAsync();
            
            return new ScheduleResponse(existingSchedule);
        }
        catch (Exception e)
        {
            // Error handling
            return new ScheduleResponse($"An error occurred while updating the schedule: {e.Message}");
        }
    }

    public async Task<ScheduleResponse> DeleteAsync(int id)
    {
        // Validate if schedule exists
        
        var existingSchedule = await _scheduleRepository.FindByIdAsync(id);
        
        if (existingSchedule == null)
            return new ScheduleResponse("Schedule not found.");
        
        // Perform delete
        
        try
        {
            _scheduleRepository.Remove(existingSchedule);
            await _unitOfWork.CompleteAsync();
            
            return new ScheduleResponse(existingSchedule);
        }
        catch (Exception e)
        {
            // Error handling
            return new ScheduleResponse($"An error occurred while deleting the payment: {e.Message}");
        }
    }
}