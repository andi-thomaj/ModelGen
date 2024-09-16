﻿using ModelGen.Application.Models.Requests;
using ModelGen.Application.Models.Responses;
using ModelGen.Shared;

namespace ModelGen.Application.Contracts.Business;

public interface IUserService
{
    Task<Result> CreateUserAsync(LoginRequest request);
    Task<Result> DeleteUserAsync(string email);
    Task<Result<UserResponse>> UpdateUserAsync(Guid id, UserUpdateRequest request);
    Task<Result<UserResponse>> GetUserByIdAsync(Guid id);
    Task<Result<UserResponse>> GetUserByEmailAsync(string email);
}