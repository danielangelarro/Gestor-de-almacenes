using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

public class AuthorizeRolesAttribute : IAsyncAuthorizationFilter
{
    private readonly string[] _roles;

    public AuthorizeRolesAttribute(params string[] roles)
    {
        _roles = roles;
    }

    public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
    {
        var userClaims = context.HttpContext.User.Claims;
        var userRole = userClaims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;

        if (!_roles.Contains(userRole))
        {
            // Manejar acceso no autorizado
            context.Result = new Microsoft.AspNetCore.Mvc.ForbidResult();
        }
    }
}