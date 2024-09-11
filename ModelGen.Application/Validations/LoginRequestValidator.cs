using FluentValidation;
using Microsoft.AspNetCore.Identity.Data;

namespace ModelGen.Application.Validations;

public class LoginRequestValidator : AbstractValidator<LoginRequest>  
{
    public LoginRequestValidator()
    {
        // RuleFor(request => request.Email)
        //     .MustAsync(async (email, _) => await userService.IsEmailUniqueAsync(email))
        //     .WithMessage("Email address is not unique");
        RuleFor(request => request.Email).NotEmpty().WithMessage("Email is required");
    }
}