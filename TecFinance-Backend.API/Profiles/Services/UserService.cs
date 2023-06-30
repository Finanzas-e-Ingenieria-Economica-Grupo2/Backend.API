using TecFinance_Backend.API.Profiles.Domain.Models;
using TecFinance_Backend.API.Profiles.Domain.Repositories;
using TecFinance_Backend.API.Profiles.Domain.Services;
using TecFinance_Backend.API.Profiles.Domain.Services.Communication;
using TecFinance_Backend.API.Shared.Domain.Repositories;

namespace TecFinance_Backend.API.Profiles.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<User>> ListAsync()
    {
        return await _userRepository.ListAsync();
    }

    public async Task<User> FindByEmailAsync(string email)
    {
        return await _userRepository.FindByEmailAsync(email);
    }

    public async Task<UserResponse> SaveAsync(User user)
    {
        // Validate existence of assigned email

        var existingUserWithEmail = await _userRepository.FindByEmailAsync(user.Email);
        
        if (existingUserWithEmail != null)
            return new UserResponse("Email is already used.");

        try
        {
            await _userRepository.AddAsync(user);
            await _unitOfWork.CompleteAsync();

            return new UserResponse(user);
        }
        catch (Exception e)
        {
            return new UserResponse($"An error occurred while saving the user: {e.Message}");
        }    
    }

    public async Task<UserResponse> UpdateAsync(int id, User user)
    {
        // Validate if user exists

        var existingUser = await _userRepository.FindByIdAsync(id);

        if (existingUser == null)
            return new UserResponse("User not found.");
        
        // Validate existence of assigned email
        
        var existingUserWithEmail = await _userRepository.FindByEmailAsync(user.Email);
        
        if (existingUserWithEmail != null && existingUserWithEmail.Id != id)
            return new UserResponse("Email is already used.");

        // Modify fields
        
        existingUser.Name = user.Name;
        existingUser.Email = user.Email;
        existingUser.Password = user.Password;

        // Perform update
        
        try
        {
            _userRepository.Update(existingUser);
            await _unitOfWork.CompleteAsync();
            
            return new UserResponse(existingUser);
        }
        catch (Exception e)
        {
            // Error handling
            return new UserResponse($"An error occurred while updating the user: {e.Message}");
        }
    }

    public async Task<UserResponse> DeleteAsync(int id)
    {
        // Validate if tutorials exists
        
        var existingUser = await _userRepository.FindByIdAsync(id);
        
        if (existingUser == null)
            return new UserResponse("User not found.");
        
        // Perform delete
        
        try
        {
            _userRepository.Remove(existingUser);
            await _unitOfWork.CompleteAsync();
            
            return new UserResponse(existingUser);
        }
        catch (Exception e)
        {
            // Error handling
            return new UserResponse($"An error occurred while deleting the user: {e.Message}");
        }
    }
}