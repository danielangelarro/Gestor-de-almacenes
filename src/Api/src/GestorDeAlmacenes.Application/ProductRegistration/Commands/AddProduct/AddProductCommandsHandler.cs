using System;
using GestorDeAlmacenes.Application.Common.Interfaces;
using GestorDeAlmacenes.Application.DTO.Product;
using GestorDeAlmacenes.Application.Entities;
using GestorDeAlmacenes.Domain.Common.Errors;
using MediatR;
using ErrorOr;
using GestorDeAlmacenes.Application.Common.Interfaces.Services;

namespace GestorDeAlmacenes.Application.Product.Commands.Add;

public class AddProductCommandsHandler : IRequestHandler<AddProductCommands, ErrorOr<ProductResult>>
{
   private readonly IProductoRepository _productRepository;
   private readonly INotificacionRepository _notificacionRepository;
   private readonly IDateTimeProvider _dateTimeProvider;

    public AddProductCommandsHandler(IProductoRepository productRepository, INotificacionRepository notificacionRepository, IDateTimeProvider dateTimeProvider)
    {
        _productRepository = productRepository;
        _notificacionRepository = notificacionRepository;
        _dateTimeProvider = dateTimeProvider;
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
            Precio_Entrada = command.Precio_Entrada,
            Precio_Salida = command.Precio_Salida
       };

       await _productRepository.AddProductoAsync(product);
       await _notificacionRepository.AddDiffusionNotificacionAsync(
            Mensaje: $"Se ha agregado el producto {product.Nombre}.",
            Tipo: "Nuevo Producto Registrado",
            Fecha: _dateTimeProvider.UtcNow
        );
       
       return new ProductResult(product);
   }
}
