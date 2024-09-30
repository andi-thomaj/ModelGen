using Microsoft.EntityFrameworkCore;
using ModelGen.Application.Contracts.Persistence;
using ModelGen.Application.Models.Requests;
using ModelGen.Application.Models.Responses;
using ModelGen.Domain;
using ModelGen.Infrastructure.Database;
using ModelGen.Shared;

namespace ModelGen.Infrastructure.Repositories;

public class UserRepository(ModelGenDbContext dbContext) : IUserRepository
{
    public async Task<Result<UserResponse>> CreateUserAsync(LoginRequest request)
    {
        var user = await dbContext.Users.FirstOrDefaultAsync(x => x.Email == request.Email);
        if (user is not null)
        {
            return await UpdateUserAsync(user.Id,
                new UserUpdateRequest(request.FirstName, user.MiddleName, request.LastName, request.Theme,
                    request.PictureUrl, request.GoogleIdToken, request.Jwt, user.IsBlocked, user.IsDeleted));
        }

        dbContext.Users.Add(new User
        {
            Email = request.Email,
            FirstName = request.FirstName,
            LastName = request.LastName,
            PictureUrl = request.PictureUrl,
            Theme = request.Theme,
            GoogleIdToken = request.GoogleIdToken,
            Jwt = request.Jwt
        });
        await dbContext.SaveChangesAsync();

        user = await dbContext.Users.FirstOrDefaultAsync(x => x.Email == request.Email);
        return new Result<UserResponse>(new UserResponse(user.Id, user.FirstName, user.MiddleName, user.LastName,
            user.Email, user.Theme, user.PictureUrl, user.GoogleIdToken, user.Jwt, user.JwtRefresh, user.LoginAttempts,
            user.IsBlocked, user.IsDeleted), true, Error.None);
    }

    public async Task<Result> DeleteUserByEmailAsync(string email)
    {
        var user = await dbContext.Users.FirstOrDefaultAsync(x => x.Email == email);
        if (user is null)
        {
            return new Result(false,
                new Error(nameof(DeleteUserByEmailAsync), $"User: {email} doesn't exist", ErrorType.NotFound));
        }

        dbContext.Users.Remove(user);
        await dbContext.SaveChangesAsync();

        return new Result(true, Error.None);
    }

    public async Task<Result> DeleteUserByIdAsync(Guid id)
    {
        var user = await dbContext.Users.FindAsync(id);
        if (user is null)
        {
            return new Result(false,
                new Error(nameof(DeleteUserByEmailAsync), $"User: {id} doesn't exist", ErrorType.NotFound));
        }

        dbContext.Users.Remove(user);
        await dbContext.SaveChangesAsync();

        return new Result(true, Error.None);
    }

    public async Task<Result<UserResponse>> UpdateUserAsync(Guid id, UserUpdateRequest request)
    {
        var user = await dbContext.Users.FindAsync(id);

        if (user is null)
        {
            return new Result<UserResponse>(null, false,
                new Error(nameof(UpdateUserAsync), $"User: {id} doesn't exist", ErrorType.NotFound));
        }

        user.FirstName = request.FirstName;
        user.MiddleName = request.MiddleName ?? string.Empty;
        user.LastName = request.LastName;
        user.Theme = request.Theme;
        user.GoogleIdToken = request.GoogleIdToken;
        user.Jwt = request.Jwt;
        user.IsBlocked = request.IsBlocked;
        user.IsDeleted = request.IsDeleted;

        await dbContext.SaveChangesAsync();

        return new Result<UserResponse>(new UserResponse(user.Id, user.FirstName, user.MiddleName, user.LastName,
            user.Email, user.Theme, user.PictureUrl, user.GoogleIdToken, user.Jwt, user.JwtRefresh, user.LoginAttempts,
            user.IsBlocked, user.IsDeleted), true, Error.None);
    }

    public async Task<Result<UserResponse>> GetUserByIdAsync(Guid id)
    {
        var user = await dbContext.Users.FindAsync(id);

        if (user is null)
        {
            return new Result<UserResponse>(null, false,
                new Error(nameof(UpdateUserAsync), $"User: {id} doesn't exist", ErrorType.NotFound));
        }

        return new Result<UserResponse>(new UserResponse(user.Id, user.FirstName, user.MiddleName, user.LastName,
            user.Email, user.Theme, user.PictureUrl, user.GoogleIdToken, user.Jwt, user.JwtRefresh, user.LoginAttempts,
            user.IsBlocked, user.IsDeleted), true, Error.None);
    }

    public async Task<Result<UserResponse>> GetUserByEmailAsync(string email)
    {
        var user = await dbContext.Users.FirstOrDefaultAsync(x => x.Email == email);

        if (user is null)
        {
            return new Result<UserResponse>(null, false,
                new Error(nameof(UpdateUserAsync), $"User: {email} doesn't exist", ErrorType.NotFound));
        }

        return new Result<UserResponse>(new UserResponse(user.Id, user.FirstName, user.MiddleName, user.LastName,
            user.Email, user.Theme, user.PictureUrl, user.GoogleIdToken, user.Jwt, user.JwtRefresh, user.LoginAttempts,
            user.IsBlocked, user.IsDeleted), true, Error.None);
    }
}