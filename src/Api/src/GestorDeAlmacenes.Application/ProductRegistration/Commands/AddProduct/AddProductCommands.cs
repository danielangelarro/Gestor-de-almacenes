using GestorDeAlmacenes.Application.DTO.Product;
using MediatR;
using ErrorOr;

namespace GestorDeAlmacenes.Application.Product.Commands.Add;

public record AddProductCommands(
   string ProductName,
   string ProductDescription,
   float ProductPrice,
   float Precio_Unitario,
   string Tipo,
   float Alto,
   float Ancho,
   float Largo,
   string Unidad_Dimensiones,
   float Peso
) : IRequest<ErrorOr<ProductResult>>;

