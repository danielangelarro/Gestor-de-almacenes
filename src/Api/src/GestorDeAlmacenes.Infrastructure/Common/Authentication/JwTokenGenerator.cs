using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using GestorDeAlmacenes.Application.Common.Interfaces.Authentication;
using GestorDeAlmacenes.Application.Common.Interfaces.Services;
using GestorDeAlmacenes.Application.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace GestorDeAlmacenes.Infrastructure.Authentication;

public class JwTokenGenerator : IJwtTokenGenerator
{
    private readonly JwtSettings _jwtSettings;
    private readonly IDateTimeProvider _dateTimeProvider;

    public JwTokenGenerator(IOptions<JwtSettings> jwtSettings, IDateTimeProvider dateTimeProvider)
    {
        _jwtSettings = jwtSettings.Value;
        _dateTimeProvider = dateTimeProvider;
    }

    public string GenerateToken(User user)
    {
        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret)),
            SecurityAlgorithms.HmacSha256
        );

        if (user.Rol is null)
        {
            user.Rol = "almacenero";
        }

        var claims = new []
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.ID_User.ToString()),
            new Claim(JwtRegisteredClaimNames.GivenName, user.Nombres),
            new Claim(JwtRegisteredClaimNames.FamilyName, user.Apellidos),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(ClaimTypes.Role, user.Rol),
        };

        var securityToken = new JwtSecurityToken(
            issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Audience,
            expires: _dateTimeProvider.UtcNow.AddMinutes(_jwtSettings.ExpiryMinutes),
            claims: claims,
            signingCredentials: signingCredentials
        );

        return new JwtSecurityTokenHandler().WriteToken(securityToken);
    }
}