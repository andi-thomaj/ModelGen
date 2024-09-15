using ModelGen.Domain;
using ModelGen.Shared;

namespace ModelGen.Application.Contracts.Business;

public interface IUserService
{
    Task<Result> CreateUserAsync(User user);
    Task<Result> DeleteUserAsync(string email);
}