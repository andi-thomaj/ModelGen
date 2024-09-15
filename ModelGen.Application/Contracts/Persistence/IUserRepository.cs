using ModelGen.Domain;
using ModelGen.Shared;

namespace ModelGen.Application.Contracts.Persistence;

public interface IUserRepository
{
    Task<Result> CreateUserAsync(User user);
    Task<Result> DeleteUserAsync(string email);
}