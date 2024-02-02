using MediatR;
using ErrorOr;
using GestorDeAlmacenes.Application.DTO.Authentication;

namespace GestorDeAlmacenes.Application.Entradas.Commands.CurrentUser;

public record GetCurrentUserQuery(
   string Token
) : IRequest<ErrorOr<AuthenticationResult>>;

