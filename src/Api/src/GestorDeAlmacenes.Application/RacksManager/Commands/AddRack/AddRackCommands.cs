using MediatR;
using ErrorOr;
using GestorDeAlmacenes.Application.DTO.Racks;

namespace GestorDeAlmacenes.Application.Racks.Commands.Add;

public record AddRackCommands(
   string Pasillo
) : IRequest<ErrorOr<RackResult>>;

