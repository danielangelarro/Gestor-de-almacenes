using MediatR;
using ErrorOr;
using GestorDeAlmacenes.Application.DTO.Mermas;

namespace GestorDeAlmacenes.Application.Mermas.Commands.Add;

public record AddMermaCommands(
   Guid ID_Merma,
   Guid ID_Producto,
   int Cantidad,
   DateTime Fecha_Caducidad
) : IRequest<ErrorOr<MermaResult>>;

