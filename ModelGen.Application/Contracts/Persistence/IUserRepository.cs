using ModelGen.Application.Models.Requests;
using ModelGen.Application.Models.Responses;
using ModelGen.Shared;

namespace ModelGen.Application.Contracts.Persistence;

public interface IUserRepository
{
    Task<Result<UserResponse>> CreateUserAsync(LoginRequest request);
    Task<Result> DeleteUserByEmailAsync(string email);
    Task<Result> DeleteUserByIdAsync(Guid id);
    Task<Result<UserResponse>> UpdateUserAsync(Guid id, UserUpdateRequest request);
    Task<Result<UserResponse>> GetUserByIdAsync(Guid id);
    Task<Result<UserResponse>> GetUserByEmailAsync(string email);
}