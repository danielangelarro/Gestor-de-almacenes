using ErrorOr;
using MediatR;
using GestorDeAlmacenes.Application.DTO.Authentication;

namespace GestorDeAlmacenes.Application.Authentication.Queries.Login;

public record LoginQuery(
    string Email,
    string Password
) : IRequest<ErrorOr<AuthenticationResult>>;