﻿namespace ModelGen.Api.Configurations;

public class JwtSettings
{
    internal const string SectionName = nameof(JwtSettings);
    public string Issuer { get; set; } = string.Empty;
    public string Audience { get; set; } = string.Empty;
    public string Key { get; set; } = string.Empty;
}