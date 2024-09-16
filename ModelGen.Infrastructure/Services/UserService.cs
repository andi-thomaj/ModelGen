using ModelGen.Application.Contracts.Business;
using ModelGen.Application.Contracts.Persistence;
using ModelGen.Application.Models.Requests;
using ModelGen.Application.Models.Responses;
using ModelGen.Shared;

namespace ModelGen.Infrastructure.Services;

public class UserService(IUserRepository userRepository) : IUserService
{
    public async Task<Result> CreateUserAsync(LoginRequest request)
    {
        try
        {
            return await userRepository.CreateUserAsync(request);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<Result> DeleteUserByEmailAsync(string email)
    {
        try
        {
            return await userRepository.DeleteUserByEmailAsync(email);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    public async Task<Result> DeleteUserByIdAsync(Guid id)
    {
        try
        {
            return await userRepository.DeleteUserByIdAsync(id);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<Result<UserResponse>> UpdateUserAsync(Guid id, UserUpdateRequest request)
    {
        try
        {
            return await userRepository.UpdateUserAsync(id, request);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public Task<Result<UserResponse>> GetUserByIdAsync(Guid id)
    {
        try
        {
            return userRepository.GetUserByIdAsync(id);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public Task<Result<UserResponse>> GetUserByEmailAsync(string email)
    {
        try
        {
            return userRepository.GetUserByEmailAsync(email);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}