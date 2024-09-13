using ModelGen.Application.Contracts.Business;
using ModelGen.Infrastructure.Repositories;

namespace ModelGen.Infrastructure.Services;

public class UserService(UserRepository userRepository) : IUserService
{
    
}