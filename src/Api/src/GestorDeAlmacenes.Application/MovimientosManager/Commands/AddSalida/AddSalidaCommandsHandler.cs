using GestorDeAlmacenes.Application.Common.Interfaces;
using GestorDeAlmacenes.Application.DTO.Salidas;
using GestorDeAlmacenes.Application.Entities;
using GestorDeAlmacenes.Domain.Common.Errors;
using MediatR;
using ErrorOr;
using Microsoft.AspNetCore.Http;
using GestorDeAlmacenes.Application.Services;
using Microsoft.VisualBasic;
using GestorDeAlmacenes.Application.Common.Interfaces.Services;

namespace GestorDeAlmacenes.Application.Salidas.Commands.Add;

public class AddSalidaCommandsHandler : IRequestHandler<AddSalidaCommands, ErrorOr<SalidaResult>>
{
    private readonly IProductoRepository _productoRepository;
    private readonly IClienteRepository _clienteRepository;
    private readonly IGetCurrentUserLoginService _getCurrentUserLoginService;
    private readonly IMovimientoRepository _movimientoRepository;
    private readonly IUbicacionRepository _ubicacionRepository;
    private readonly IUbicacionSalidaRepository _ubicacionSalidaRepository;
    private readonly IRackRepository _rackRepository;
    private readonly ICasilleroRepository _casilleroRepository;
    private readonly IDateTimeProvider _dateTimeProvider;
    private readonly INotificacionRepository _notificacionRepository;

    public AddSalidaCommandsHandler(
        IProductoRepository productoRepository,
        IClienteRepository clienteRepository,
        IGetCurrentUserLoginService getCurrentUserLoginService,
        IMovimientoRepository movimientoRepository,
        IUbicacionRepository ubicacionRepository,
        IUbicacionSalidaRepository ubicacionSalidaRepository,
        IRackRepository rackRepository,
        ICasilleroRepository casilleroRepository,
        INotificacionRepository notificacionRepository,
        IDateTimeProvider dateTimeProvider)
    {
        _productoRepository = productoRepository;
        _clienteRepository = clienteRepository;
        _getCurrentUserLoginService = getCurrentUserLoginService;
        _movimientoRepository = movimientoRepository;
        _ubicacionRepository = ubicacionRepository;
        _ubicacionSalidaRepository = ubicacionSalidaRepository;
        _rackRepository = rackRepository;
        _casilleroRepository = casilleroRepository;
        _notificacionRepository = notificacionRepository;
        _dateTimeProvider = dateTimeProvider;
    }

    public async Task<ErrorOr<SalidaResult>> Handle(AddSalidaCommands command, CancellationToken cancellationToken)
    {
        if (await _getCurrentUserLoginService.Handle(command.Token) is not User user)
        {
            return Errors.Authentication.InvalidCredentials;
        }

        if (await _productoRepository.GetProductoByIdAsync(command.ID_Producto) is not Producto product)
        {
            return Errors.Producto.NotFound;
        }
        
        if (await _clienteRepository.GetClienteByIdAsync(command.ID_Usuario) is not Cliente cliente)
        {
            return Errors.Cliente.NotFound;
        }
        
        if (await _rackRepository.GetWaitRacksAsync() is not Rack rack_wait)
        {
            return Errors.Rack.NotFoundWait;
        }

        var salida = new Movimientos
        {
            ID_Movimiento = Guid.NewGuid(),
            ID_Producto = command.ID_Producto,
            ID_Usuario = user.ID_User,
            ID_Cliente = command.ID_Usuario,
            Cliente_Name = cliente.Nombres + " " + cliente.Apellidos,
            Autorization = user.Nombres + " " + user.Apellidos,
            Producto_Name = product.Nombre,
            Cantidad = command.Cantidad,
            Precio_Unidad = command.Precio_Unidad,
            Fecha = command.Fecha,
            Fecha_Caducidad = command.Fecha
        };

        await _movimientoRepository.AddSalidaAsync(salida);
        await _notificacionRepository.AddDiffusionNotificacionAsync(
            Mensaje: $"Han salido {command.Cantidad} {product.Nombre}.",
            Tipo: "Nueva Venta de producto",
            Fecha: _dateTimeProvider.UtcNow
        );

        var ubicaciones_actuales_result = await _ubicacionRepository.GetAllUbicacionesByProductoAsync(product.ID_Producto);
        if (ubicaciones_actuales_result == null)
        {
            return Errors.Ubicacion.NotFound;
        }

        var ubicaciones_actuales = ubicaciones_actuales_result.OrderByDescending(u => u.Fecha_Caducidad);
        var casillero_wait = (await _casilleroRepository.GetAllCasillerosByRackIdAsync(rack_wait.ID_Rack)).FirstOrDefault();

        List<Ubicacion_Salida> ubicaciones = new List<Ubicacion_Salida>();
        int cantidad = command.Cantidad;

        foreach (var ubicacion in ubicaciones_actuales)
        {
            if (ubicacion.ID_Casillero == casillero_wait.ID_Casillero)
            {
                continue;
            }

            int cantidad_ubicacion = ubicacion.Cantidad;

            if (cantidad <= 0)
            {
                break;
            } 

            if (cantidad_ubicacion <= cantidad)
            {
                var casillero = await _casilleroRepository.GetCasilleroByIdAsync(ubicacion.ID_Casillero);
                var rack = await _rackRepository.GetRackByIdAsync(casillero.ID_Rack);

                cantidad -= cantidad_ubicacion;
                var ubicacion_salida = new Ubicacion_Salida {
                    ID_Ubicacion_Salida = Guid.NewGuid(),
                    ID_Salida = salida.ID_Movimiento,
                    ID_Ubicacion = ubicacion.ID_Ubicacion,
                    Indice_Casillero = casillero.Index,
                    Pasillo = rack.Pasillo
                };

                ubicaciones.Add(ubicacion_salida);
                await _ubicacionSalidaRepository.AddUbicacionSalidaAsync(ubicacion_salida);
                await _ubicacionRepository.DeleteUbicacionAsync(ubicacion);
            } 
            else
            {
                ubicacion.Cantidad -= cantidad;
                await _ubicacionRepository.UpdateUbicacionAsync(ubicacion);
            }
        }
        
        return new SalidaResult(salida, ubicaciones);
    }
}
