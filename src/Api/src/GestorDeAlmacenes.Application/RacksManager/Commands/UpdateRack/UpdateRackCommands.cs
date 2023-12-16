using GestorDeAlmacenes.Application.DTO.Racks;
using MediatR;
using ErrorOr;

namespace GestorDeAlmacenes.Application.Racks.Commands.Update;

public record UpdateRackCommands(
   Guid Id,
   string Pasillo
) : IRequest<ErrorOr<RackResult>>;
