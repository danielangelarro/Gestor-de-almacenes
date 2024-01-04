using System;
using GestorDeAlmacenes.Application.Common.Interfaces;
using GestorDeAlmacenes.Application.DTO.Product;
using GestorDeAlmacenes.Application.Entities;
using GestorDeAlmacenes.Domain.Common.Errors;
using MediatR;
using ErrorOr;

namespace GestorDeAlmacenes.Application.Product.Commands.Add;

public class AddProductCommandsHandler : IRequestHandler<AddProductCommands, ErrorOr<ProductResult>>
{
   private readonly IProductoRepository _productRepository;

   public AddProductCommandsHandler(IProductoRepository productRepository)
   {
       _productRepository = productRepository;
   }

   public async Task<ErrorOr<ProductResult>> Handle(AddProductCommands command, CancellationToken cancellationToken)
   {
       var product = new Producto
       {
            ID_Producto = Guid.NewGuid(),
            Nombre = command.ProductName,
            Descripcion = command.ProductDescription,
            Tipo = command.Tipo,
            Alto = command.Alto,
            Ancho = command.Ancho,
            Largo = command.Largo,
            Unidad_Dimensiones = command.Unidad_Dimensiones,
            Peso = command.Peso,
       };

       await _productRepository.AddProductoAsync(product);
       
       return new ProductResult(product);
   }
}
