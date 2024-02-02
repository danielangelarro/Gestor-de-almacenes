using System.Data;
using GestorDeAlmacenes.Application.Common.Interfaces;
using GestorDeAlmacenes.Application.DTO.Entradas;
using GestorDeAlmacenes.Application.Entities;
using GestorDeAlmacenes.Domain.Common.Errors;
using MediatR;
using ErrorOr;
using GestorDeAlmacenes.Application.Common.Interfaces.Services;
using GestorDeAlmacenes.Application.Services;

namespace GestorDeAlmacenes.Application.Entradas.Commands.Add;

public class AddEntradaCommandsHandler : IRequestHandler<AddEntradaCommands, ErrorOr<EntradaResult>>
{
    private readonly IMovimientoRepository _movimientoRepository;
    private readonly IProductoRepository _productoRepository;
    private readonly IProveedorRepository _proveedorRepository;
    private readonly IRackRepository _rackRepository;
    private readonly IUbicacionRepository _ubicacionRepository;
    private readonly ICasilleroRepository _casilleroRepository;
    private readonly IDateTimeProvider dateTimeProvider;
    private readonly IGetCurrentUserLoginService _getCurrentUserLoginService;
    private readonly IDateTimeProvider _dateTimeProvider;
    private readonly INotificacionRepository _notificacionRepository;

    public AddEntradaCommandsHandler(
        IProductoRepository productoRepository,
        IMovimientoRepository movimientoRepository,
        IProveedorRepository proveedorRepository,
        IRackRepository rackRepository,
        IUbicacionRepository ubicacionRepository,
        ICasilleroRepository casilleroRepository,
        IGetCurrentUserLoginService getCurrentUserLoginService,
        IDateTimeProvider dateTimeProvider,
        INotificacionRepository notificacionRepository)
    {
        _productoRepository = productoRepository;
        _movimientoRepository = movimientoRepository;
        _proveedorRepository = proveedorRepository;
        _rackRepository = rackRepository;
        _ubicacionRepository = ubicacionRepository;
        _casilleroRepository = casilleroRepository;
        _getCurrentUserLoginService = getCurrentUserLoginService;
        _dateTimeProvider = dateTimeProvider;
        _notificacionRepository = notificacionRepository;
    }

    public async Task<ErrorOr<EntradaResult>> Handle(AddEntradaCommands command, CancellationToken cancellationToken)
    {
        if (await _getCurrentUserLoginService.Handle(command.Token) is not User user)
        {
            return Errors.Authentication.InvalidCredentials;
        }

        if (await _productoRepository.GetProductoByIdAsync(command.ID_Producto) is not Producto product)
        {
            return Errors.Producto.NotFound;
        }
        
        if (await _proveedorRepository.GetProveedorByIdAsync(command.ID_Usuario) is not Proveedor proveedor)
        {
            return Errors.Proveedor.NotFound;
        }

        if (await _rackRepository.GetWaitRacksAsync() is not Rack rack)
        {
            return Errors.Rack.NotFoundWait;
        }

        if ((await _casilleroRepository.GetAllCasillerosByRackIdAsync(rack.ID_Rack)).FirstOrDefault() is not Casillero casillero)
        {
            return Errors.Casillero.NotFound;
        }

        var entrada = new Movimientos
        {
            ID_Movimiento = Guid.NewGuid(),
            ID_Producto = command.ID_Producto,
            ID_Usuario = user.ID_User,
            ID_Proveedor = command.ID_Usuario,
            Proveedor_Name = proveedor.Nombres + " " + proveedor.Apellidos,
            Autorization = user.Nombres + " " + user.Apellidos,
            Producto_Name = product.Nombre,
            Cantidad = command.Cantidad,
            Precio_Unidad = command.Precio_Unidad,
            Fecha = command.Fecha,
            Fecha_Caducidad = command.Fecha_Caducidad
        };

        await _movimientoRepository.AddEntradaAsync(entrada);
        await _notificacionRepository.AddDiffusionNotificacionAsync(
            Mensaje: $"Ha entrado {command.Cantidad} de {product.Nombre}.",
            Tipo: "Nueva Compra de producto",
            Fecha: _dateTimeProvider.UtcNow
        );

        // Agregar al rack de espera

        await _ubicacionRepository.AddUbicacionAsync(
            new Ubicacion{
                ID_Ubicacion = Guid.NewGuid(),
                ID_Producto = entrada.ID_Producto,
                ID_Casillero = casillero.ID_Casillero,
                Cantidad = entrada.Cantidad,
                Fecha_Llegada = entrada.Fecha,
                Fecha_Caducidad = entrada.Fecha_Caducidad,
                Confirmar_Guardado = false
            }
        );

        return new EntradaResult(entrada);
    }
}
