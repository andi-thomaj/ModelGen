﻿namespace ModelGen.Application.Models.Requests;

public class LoginRequest
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Theme { get; set; }  = string.Empty;
    public string PictureUrl { get; set; } = string.Empty;
}