using GestorDeAlmacenes.Application.Common.Interfaces;
using GestorDeAlmacenes.Application.DTO.Mermas;
using GestorDeAlmacenes.Application.Entities;
using GestorDeAlmacenes.Domain.Common.Errors;
using MediatR;
using ErrorOr;
using GestorDeAlmacenes.Application.Common.Interfaces.Services;

namespace GestorDeAlmacenes.Application.Mermas.Commands.Add;

public class AddMermaCommandsHandler : IRequestHandler<AddMermaCommands, ErrorOr<MermaResult>>
{
    private readonly IMovimientoRepository _movimientoRepository;
    private readonly IDateTimeProvider _dateTimeProvider;
    private readonly IProductoRepository _productoRepository;
    private readonly INotificacionRepository _notificacionRepository;


    public AddMermaCommandsHandler(IMovimientoRepository movimientoRepository, IDateTimeProvider dateTimeProvider, IProductoRepository productoRepository, INotificacionRepository notificacionRepository)
    {
        _movimientoRepository = movimientoRepository;
        _dateTimeProvider = dateTimeProvider;
        _productoRepository = productoRepository;
        _notificacionRepository = notificacionRepository;
    }

    public async Task<ErrorOr<MermaResult>> Handle(AddMermaCommands command, CancellationToken cancellationToken)
    {
        if (await _productoRepository.GetProductoByIdAsync(command.ID_Producto) is not Producto product)
        {
            return Errors.Producto.NotFound;
        }

        var merma = new Movimientos
        {
            ID_Movimiento = Guid.NewGuid(),
            ID_Producto = command.ID_Producto,
            Producto_Name = product.Nombre,
            Cantidad = command.Cantidad,
            Descripcion = command.Descripcion,
            Fecha = _dateTimeProvider.UtcNow,
            Fecha_Caducidad = command.Fecha_Caducidad
        };

        await _movimientoRepository.AddMermaAsync(merma);
        await _notificacionRepository.AddDiffusionNotificacionAsync(
            Mensaje: $"Han mermado {command.Cantidad} {product.Nombre}.",
            Tipo: "Nueva Merma de producto",
            Fecha: _dateTimeProvider.UtcNow
        );

        return new MermaResult(merma);
    }
}
