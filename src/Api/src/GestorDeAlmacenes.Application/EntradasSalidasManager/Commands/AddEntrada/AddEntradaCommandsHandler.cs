using System.Data;
using GestorDeAlmacenes.Application.Common.Interfaces;
using GestorDeAlmacenes.Application.DTO.Entradas;
using GestorDeAlmacenes.Application.Entities;
using GestorDeAlmacenes.Domain.Common.Errors;
using MediatR;
using ErrorOr;
using GestorDeAlmacenes.Application.Common.Interfaces.Repository;
using Microsoft.AspNetCore.Http;

namespace GestorDeAlmacenes.Application.Entradas.Commands.Add;

public class AddEntradaCommandsHandler : IRequestHandler<AddEntradaCommands, ErrorOr<EntradaResult>>
{
    private readonly IEntradaRepository _entradaRepository;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IProductoRepository _productoRepository;

    public AddEntradaCommandsHandler(IEntradaRepository entradaRepository, IProductoRepository productoRepository, IHttpContextAccessor httpContextAccessor)
    {
        _entradaRepository = entradaRepository;
        _productoRepository = productoRepository;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<ErrorOr<EntradaResult>> Handle(AddEntradaCommands command, CancellationToken cancellationToken)
    {
        if (await _productoRepository.GetProductoByIdAsync(command.ID_Producto) is not Producto product)
        {
            return Errors.Producto.NotFound;
        }

        var user = _httpContextAccessor.HttpContext.User;
        var username = user.Identity.Name;

        var entrada = new Entrada
        {
            ID_Entrada = Guid.NewGuid(),
            ID_Producto = command.ID_Producto,
            ID_Usuario = command.ID_Usuario,
            Autor = username,
            Producto_Name = product.Nombre,
            Cantidad = command.Cantidad,
            Fecha = command.Fecha
        };

        await _entradaRepository.AddEntradaAsync(entrada);
        
        return new EntradaResult(entrada);
    }
}
