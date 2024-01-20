using GestorDeAlmacenes.Application.DTO.Product;
using MediatR;
using ErrorOr;

namespace GestorDeAlmacenes.Application.Product.Commands.Update;

public record UpdateProductCommands(
   Guid Id,
   string ProductName,
   string ProductDescription,
   string Tipo,
   float Alto,
   float Ancho,
   float Largo,
   string Unidad_Dimensiones,
   float Peso,
   float Precio_Entrada,
   float Precio_Salida,
   bool EnAlmacen
) : IRequest<ErrorOr<ProductResult>>;

