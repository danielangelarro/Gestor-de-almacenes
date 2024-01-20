using MediatR;
using ErrorOr;
using GestorDeAlmacenes.Application.DTO.Salidas;

namespace GestorDeAlmacenes.Application.Salidas.Commands.Add;

public record AddSalidaCommands(
   Guid ID_Producto,
   Guid ID_Usuario,
   int Cantidad,
   float Precio_Unidad,
   DateTime Fecha,
   string Token
) : IRequest<ErrorOr<SalidaResult>>;

