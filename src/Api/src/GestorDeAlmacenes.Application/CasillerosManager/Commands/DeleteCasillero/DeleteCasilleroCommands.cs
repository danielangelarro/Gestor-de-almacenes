using GestorDeAlmacenes.Application.DTO.Casilleros;
using MediatR;
using ErrorOr;

namespace GestorDeAlmacenes.Application.Casilleros.Commands.Delete;

public record DeleteCasilleroCommands(
   Guid Id_Casillero
) : IRequest<ErrorOr<CasilleroResult>>;

