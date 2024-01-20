using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using MediatR;
using ErrorOr;
using GestorDeAlmacenes.Application.Product.Query.GetAllProducts;
using GestorDeAlmacenes.Application.DTO.Product;
using GestorDeAlmacenes.Application.Product.Query.GetProductById;
using GestorDeAlmacenes.Application.Product.Commands.Delete;
using GestorDeAlmacenes.Application.Product.Commands.Update;
using GestorDeAlmacenes.Application.Product.Commands.Add;
using GestorDeAlmacenes.Application.Product.Query.GetWaitProducts;
using GestorDeAlmacenes.Application.Product.Commands.Move;
using GestorDeAlmacenes.Application.Product.Commands.Confirm;


namespace GestorDeAlmacenes.API.Controllers;

[Authorize]
[Route("product")]
public class ProductController : ApiController
{
    private readonly ISender _mediator;

    public ProductController(ISender mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetProducts()
    {
        var query = new GetAllProductsQuery();

        ErrorOr<ProductResultList> productResultList = await _mediator.Send(query);
        
        return productResultList.Match(
            result => Ok(productResultList),
            errors => Problem(errors)
        );
    }
    
    [HttpGet("wait")]
    public async Task<IActionResult> GetWaitProducts()
    {
        var query = new GetWaitProductsQuery();

        ErrorOr<ProductResultUbicacionList> productResultUbicacionList = await _mediator.Send(query);
        
        return productResultUbicacionList.Match(
            result => Ok(productResultUbicacionList),
            errors => Problem(errors)
        );
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductById(Guid id)
    {
        var query = new GetProductByIdQuery(id);

        ErrorOr<ProductResult> productResult = await _mediator.Send(query);
        
        return productResult.Match(
            result => Ok(productResult),
            errors => Problem(errors)
        );
    }
    
    [HttpPost("transaction/move")]
    public async Task<IActionResult> MoveProduct(ProductMoveUpload request)
    {
        var query = new MoveProductCommands(
            request.Ubicacion,
            request.ID_Casillero_New,
            request.Cantidad
        );

        ErrorOr<UbicacionResult> ubicacionResult = await _mediator.Send(query);
        
        return ubicacionResult.Match(
            result => Ok(ubicacionResult),
            errors => Problem(errors)
        );
    }
    
    [HttpPost("transaction/confirm")]
    public async Task<IActionResult> ConfirmProduct(ProductConfirmUpload request)
    {
        var query = new ConfirmProductCommands(
            request.Ubicacion
        );

        ErrorOr<UbicacionResult> ubicacionResult = await _mediator.Send(query);
        
        return ubicacionResult.Match(
            result => Ok(ubicacionResult),
            errors => Problem(errors)
        );
    }
    
    [HttpPost]
    public async Task<IActionResult> AddProduct(ProductUploadRequest request)
    {
        var query = new AddProductCommands(
            request.Nombre,
            request.Descripcion,
            request.Tipo,
            request.Alto,
            request.Ancho,
            request.Largo,
            request.Unidad_Dimensiones,
            request.Peso,
            request.Precio_Entrada,
            request.Precio_Salida
        );

        ErrorOr<ProductResult> productResult = await _mediator.Send(query);
        
        return productResult.Match(
            result => Ok(productResult),
            errors => Problem(errors)
        );
    }
    
    [HttpPut]
    public async Task<IActionResult> UpdateProduct(ProductUpdateRequest request)
    {
        var query = new UpdateProductCommands(
            request.ID_Producto,
            request.Nombre,
            request.Descripcion,
            request.Tipo,
            request.Alto,
            request.Ancho,
            request.Largo,
            request.Unidad_Dimensiones,
            request.Peso,
            request.Precio_Entrada,
            request.Precio_Salida,
            request.EnAlmacen
        );

        ErrorOr<ProductResult> productResult = await _mediator.Send(query);
        
        return productResult.Match(
            result => Ok(productResult),
            errors => Problem(errors)
        );
    }
    
    [HttpDelete("{productId}")]
    public async Task<IActionResult> DeleteProduct(Guid productId)
    {
        var query = new DeleteProductCommands(productId);

        ErrorOr<ProductResult> productResult = await _mediator.Send(query);
        
        return productResult.Match(
            result => Ok(),
            errors => Problem(errors)
        );
    }
}