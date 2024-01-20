using GestorDeAlmacenes.Application.DTO.Product;
using MediatR;
using ErrorOr;

namespace GestorDeAlmacenes.Application.Product.Commands.Add;

public record AddProductCommands(
   string ProductName,
   string ProductDescription,
   string Tipo,
   float Alto,
   float Ancho,
   float Largo,
   string Unidad_Dimensiones,
   float Peso,
   float Precio_Entrada,
   float Precio_Salida
) : IRequest<ErrorOr<ProductResult>>;

