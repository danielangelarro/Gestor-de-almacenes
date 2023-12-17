using MediatR;
using ErrorOr;
using GestorDeAlmacenes.Application.DTO.Entradas;

namespace GestorDeAlmacenes.Application.Entradas.Commands.Add;

public record AddEntradaCommands(
   Guid ID_Producto,
   Guid ID_Usuario,
   int Cantidad,
   DateTime Fecha
) : IRequest<ErrorOr<EntradaResult>>;

