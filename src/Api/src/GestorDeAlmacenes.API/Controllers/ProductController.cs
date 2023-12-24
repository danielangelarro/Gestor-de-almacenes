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
    
    
    [HttpPost]
    public async Task<IActionResult> AddProduct(ProductUploadRequest request)
    {
        var query = new AddProductCommands(
            request.Nombre,
            request.Descripcion,
            request.Precio_Total,
            request.Precio_Unitario,
            request.Tipo,
            request.Alto,
            request.Ancho,
            request.Largo,
            request.Unidad_Dimensiones,
            request.Peso
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
            request.Precio_Total,
            request.Precio_Unitario,
            request.Tipo,
            request.Alto,
            request.Ancho,
            request.Largo,
            request.Unidad_Dimensiones,
            request.Peso
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