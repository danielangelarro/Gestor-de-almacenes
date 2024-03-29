using System.Net.Http.Headers;
using GestorDeAlmacenes.Application.Common.Interfaces;
using GestorDeAlmacenes.Application.DTO.Product;
using GestorDeAlmacenes.Application.Entities;
using GestorDeAlmacenes.Domain.Common.Errors;
using MediatR;
using ErrorOr;

namespace GestorDeAlmacenes.Application.Product.Commands.Update;

public class UpdateProductCommandsHandler : IRequestHandler<UpdateProductCommands, ErrorOr<ProductResult>>
{
   private readonly IProductoRepository _productRepository;

   public UpdateProductCommandsHandler(IProductoRepository productRepository)
   {
       _productRepository = productRepository;
   }

   public async Task<ErrorOr<ProductResult>> Handle(UpdateProductCommands command, CancellationToken cancellationToken)
   {
        if (await _productRepository.GetProductoByIdAsync(command.Id) is not Producto product)
        {
            return Errors.Producto.NotFound;
        }

        product.Nombre = command.ProductName;
        product.Descripcion = command.ProductDescription;
        product.Tipo = command.Tipo;
        product.Alto = command.Alto;
        product.Ancho = command.Ancho;
        product.Largo = command.Largo;
        product.Unidad_Dimensiones = command.Unidad_Dimensiones;
        product.Peso = command.Peso;
        product.EnAlmacen = command.EnAlmacen;
        product.Precio_Entrada = command.Precio_Entrada;
        product.Precio_Salida = command.Precio_Salida;

       await _productRepository.UpdateProductoAsync(product);
       
       return new ProductResult(product);
   }
}
