using ErrorOr;
using MediatR;
using GestorDeAlmacenes.Application.DTO.Authentication;

namespace GestorDeAlmacenes.Application.Authentication.Commands.Register;

public record RegisterCommand(
    string FirstName,
    string LastName,
    string Email,
    string Password
) : IRequest<ErrorOr<AuthenticationResult>>;