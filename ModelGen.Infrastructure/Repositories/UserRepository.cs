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
    public async Task<Result> CreateUserAsync(LoginRequest request)
    {
        var userExists = await dbContext.Users.AnyAsync(x => x.Email == request.Email);
        if (userExists)
        {
            return new Result(false, new Error(nameof(CreateUserAsync), $"User: {request.Email} already exists", ErrorType.Conflict));
        }
        
        dbContext.Users.Add(new User
        {
            Email = request.Email,
            FirstName = request.FirstName,
            LastName = request.LastName,
            PictureUrl = request.PictureUrl,
            Theme = request.Theme,
        });
        await dbContext.SaveChangesAsync();
        
        return new Result(true, Error.None);
    }

    public async Task<Result> DeleteUserAsync(string email)
    {
        var user = await dbContext.Users.FirstOrDefaultAsync(x => x.Email == email);
        if (user is null)
        {
            return new Result(false, new Error(nameof(DeleteUserAsync), $"User: {email} doesn't exist", ErrorType.NotFound));
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
            return new Result<UserResponse>(null, false, new Error(nameof(UpdateUserAsync), $"User: {id} doesn't exist", ErrorType.NotFound));
        }
        
        user.FirstName = request.FirstName;
        user.MiddleName = request.MiddleName;
        user.LastName = request.LastName;
        user.Theme = request.Theme;
        
        await dbContext.SaveChangesAsync();
        
        return new Result<UserResponse>(new UserResponse
        {
            Id = user.Id,
            FirstName = user.FirstName,
            MiddleName = user.MiddleName,
            LastName = user.LastName,
            Email = user.Email,
            PictureUrl = user.PictureUrl,
        }, true, Error.None);
    }

    public async Task<Result<UserResponse>> GetUserByIdAsync(Guid id)
    {
        var user = await dbContext.Users.FindAsync(id);
        
        if (user is null)
        {
            return new Result<UserResponse>(null, false, new Error(nameof(UpdateUserAsync), $"User: {id} doesn't exist", ErrorType.NotFound));
        }
        
        return new Result<UserResponse>(new UserResponse
        {
            Id = user.Id,
            FirstName = user.FirstName,
            MiddleName = user.MiddleName,
            LastName = user.LastName,
            Email = user.Email,
            PictureUrl = user.PictureUrl,
        }, true, Error.None);
    }

    public async Task<Result<UserResponse>> GetUserByEmailAsync(string email)
    {
        var user = await dbContext.Users.FirstOrDefaultAsync(x => x.Email == email);
        
        if (user is null)
        {
            return new Result<UserResponse>(null, false, new Error(nameof(UpdateUserAsync), $"User: {email} doesn't exist", ErrorType.NotFound));
        }
        
        return new Result<UserResponse>(new UserResponse
        {
            Id = user.Id,
            FirstName = user.FirstName,
            MiddleName = user.MiddleName,
            LastName = user.LastName,
            Email = user.Email,
            PictureUrl = user.PictureUrl,
        }, true, Error.None);
    }
}