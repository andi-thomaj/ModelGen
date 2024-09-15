using Microsoft.EntityFrameworkCore;
using ModelGen.Application.Contracts.Persistence;
using ModelGen.Domain;
using ModelGen.Infrastructure.Database;
using ModelGen.Shared;

namespace ModelGen.Infrastructure.Repositories;

public class UserRepository(ModelGenDbContext dbContext) : IUserRepository
{
    public async Task<Result> CreateUserAsync(User user)
    {
        var userExists = await dbContext.Users.AnyAsync(x => x.Email == user.Email);
        if (userExists)
        {
            new Result(false, new Error(nameof(CreateUserAsync), $"User: {user.Email} already exists", ErrorType.Conflict));
        }
        
        dbContext.Users.Add(user);
        await dbContext.SaveChangesAsync();
        
        return new Result(true, Error.None);
    }
}