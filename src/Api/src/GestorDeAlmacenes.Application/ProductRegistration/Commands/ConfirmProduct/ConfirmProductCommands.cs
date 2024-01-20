using GestorDeAlmacenes.Application.DTO.Product;
using MediatR;
using ErrorOr;

namespace GestorDeAlmacenes.Application.Product.Commands.Confirm;

public record ConfirmProductCommands(
   Guid Ubicacion
) : IRequest<ErrorOr<UbicacionResult>>;

