using Microsoft.AspNetCore.Mvc;
using ModelGen.Application.Contracts.Business;
using ModelGen.Application.Models.Requests;
using ModelGen.Application.Models.Responses;
using ModelGen.Shared;

namespace ModelGen.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController(IUserService userService) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<UserResponse>> GetUserByEmailAsync([FromQuery] string email)
    {
        var result = await userService.GetUserByEmailAsync(email);

        return result switch
        {
            { IsFailure: true, Error.Type: ErrorType.NotFound } => NotFound(result.Error.Description),
            { IsFailure: true } => BadRequest(),
            _ => result.Value
        };
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<UserResponse>> GetUserByIdAsync(Guid id)
    {
        var result = await userService.GetUserByIdAsync(id);

        return result switch
        {
            { IsFailure: true, Error.Type: ErrorType.NotFound } => NotFound(result.Error.Description),
            { IsFailure: true } => BadRequest(),
            _ => result.Value
        };
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<UserResponse>> UpdateUserAsync(Guid id, UserUpdateRequest request)
    {
        var result = await userService.UpdateUserAsync(id, request);

        return result switch
        {
            { IsFailure: true, Error.Type: ErrorType.NotFound } => NotFound(result.Error.Description),
            { IsFailure: true } => BadRequest(),
            _ => result.Value
        };
    }

    [HttpDelete]
    public async Task<ActionResult> DeleteUserByEmailAsync([FromQuery] string email)
    {
        var result = await userService.DeleteUserByEmailAsync(email);

        return result.IsFailure switch
        {
            true => BadRequest(result.Error),
            _ => Ok()
        };
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteUserByIdAsync(Guid id)
    {
        var result = await userService.DeleteUserByIdAsync(id);

        return result.IsFailure switch
        {
            true => BadRequest(result.Error),
            _ => Ok()
        };
    }

}