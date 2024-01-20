using MediatR;
using ErrorOr;
using GestorDeAlmacenes.Application.DTO.Entradas;

namespace GestorDeAlmacenes.Application.Entradas.Commands.Add;

public record AddEntradaCommands(
   Guid ID_Producto,
   Guid ID_Usuario,
   int Cantidad,
   float Precio_Unidad,
   DateTime Fecha,
   DateTime Fecha_Caducidad,
   string Token
) : IRequest<ErrorOr<EntradaResult>>;

