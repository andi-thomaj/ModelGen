using ModelGen.Application.Contracts.Business;
using ModelGen.Application.Contracts.Persistence;
using ModelGen.Domain;
using ModelGen.Shared;

namespace ModelGen.Infrastructure.Services;

public class UserService(IUserRepository userRepository) : IUserService
{
    public async Task<Result> CreateUserAsync(User user)
    {
        try
        {
            return await userRepository.CreateUserAsync(user);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}