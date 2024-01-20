using GestorDeAlmacenes.Application.DTO.Product;
using MediatR;
using ErrorOr;

namespace GestorDeAlmacenes.Application.Product.Commands.Move;

public record MoveProductCommands(
   Guid Ubicacion,
   Guid ID_Casillero_New,
   int Cantidad
) : IRequest<ErrorOr<UbicacionResult>>;

