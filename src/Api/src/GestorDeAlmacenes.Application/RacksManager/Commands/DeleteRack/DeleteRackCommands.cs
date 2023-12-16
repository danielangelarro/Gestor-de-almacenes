using GestorDeAlmacenes.Application.DTO.Racks;
using MediatR;
using ErrorOr;

namespace GestorDeAlmacenes.Application.Racks.Commands.Delete;

public record DeleteRackCommands(
   Guid Id
) : IRequest<ErrorOr<RackResult>>;

