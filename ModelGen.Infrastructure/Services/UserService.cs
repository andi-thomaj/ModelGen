using ModelGen.Application.Contracts.Business;
using ModelGen.Application.Contracts.Persistence;
using ModelGen.Infrastructure.Repositories;

namespace ModelGen.Infrastructure.Services;

public class UserService(IUserRepository userRepository) : IUserService
{
    
}