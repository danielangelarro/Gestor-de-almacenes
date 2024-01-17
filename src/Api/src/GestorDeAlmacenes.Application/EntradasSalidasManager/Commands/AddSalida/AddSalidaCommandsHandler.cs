using GestorDeAlmacenes.Application.Common.Interfaces;
using GestorDeAlmacenes.Application.DTO.Salidas;
using GestorDeAlmacenes.Application.Entities;
using GestorDeAlmacenes.Domain.Common.Errors;
using MediatR;
using ErrorOr;
using Microsoft.AspNetCore.Http;

namespace GestorDeAlmacenes.Application.Salidas.Commands.Add;

public class AddSalidaCommandsHandler : IRequestHandler<AddSalidaCommands, ErrorOr<SalidaResult>>
{
   private readonly ISalidaRepository _salidaRepository;
   private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IProductoRepository _productoRepository;

    public AddSalidaCommandsHandler(ISalidaRepository salidaRepository, IHttpContextAccessor httpContextAccessor, IProductoRepository productoRepository)
    {
        _salidaRepository = salidaRepository;
        _httpContextAccessor = httpContextAccessor;
        _productoRepository = productoRepository;
    }

    public async Task<ErrorOr<SalidaResult>> Handle(AddSalidaCommands command, CancellationToken cancellationToken)
    {
        if (await _productoRepository.GetProductoByIdAsync(command.ID_Producto) is not Producto product)
        {
            return Errors.Producto.NotFound;
        }

        var user = _httpContextAccessor.HttpContext.User;
        var username = user.Identity.Name;

        var salida = new Salida
        {
            ID_Salida = Guid.NewGuid(),
            ID_Producto = command.ID_Producto,
            ID_Usuario = command.ID_Usuario,
            Autor = username,
            Producto_Name = product.Nombre,
            Cantidad = command.Cantidad,
            Fecha = command.Fecha
        };

        await _salidaRepository.AddSalidaAsync(salida);
        
        return new SalidaResult(salida);
    }
}
