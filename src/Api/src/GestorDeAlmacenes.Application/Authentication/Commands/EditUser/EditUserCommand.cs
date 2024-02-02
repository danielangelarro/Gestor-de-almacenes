using ErrorOr;
using MediatR;
using GestorDeAlmacenes.Application.DTO.Authentication;
using Microsoft.AspNetCore.Http;

namespace GestorDeAlmacenes.Application.Authentication.Commands.EditUser;

public record EditUserCommand(
    string FirstName,
    string LastName,
    string Email,
    string Password,
    IFormFile File
) : IRequest<ErrorOr<AuthenticationResult>>;