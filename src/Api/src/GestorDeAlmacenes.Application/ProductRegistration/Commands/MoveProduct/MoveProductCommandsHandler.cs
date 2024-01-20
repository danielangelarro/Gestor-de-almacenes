using System;
using GestorDeAlmacenes.Application.Common.Interfaces;
using GestorDeAlmacenes.Application.DTO.Product;
using GestorDeAlmacenes.Application.Entities;
using GestorDeAlmacenes.Domain.Common.Errors;
using MediatR;
using ErrorOr;

namespace GestorDeAlmacenes.Application.Product.Commands.Move;

public class MoveProductCommandsHandler : IRequestHandler<MoveProductCommands, ErrorOr<UbicacionResult>>
{
   private readonly IUbicacionRepository _ubicacionRepository;

    public MoveProductCommandsHandler(IUbicacionRepository ubicacionRepository)
    {
        _ubicacionRepository = ubicacionRepository;
    }

    public async Task<ErrorOr<UbicacionResult>> Handle(MoveProductCommands command, CancellationToken cancellationToken)
    {
        if (await _ubicacionRepository.GetUbicacionByIdAsync(command.Ubicacion) is not Ubicacion ubicacion)
        {
            return Errors.Ubicacion.NotFound;
        }

        if (command.Cantidad == ubicacion.Cantidad)
        {
            ubicacion.ID_Casillero = command.ID_Casillero_New;
            await _ubicacionRepository.UpdateUbicacionAsync(ubicacion);

            return new UbicacionResult(ubicacion);
        }
        
        ubicacion.Cantidad -= command.Cantidad;

        var new_ubicacion = new Ubicacion {
            ID_Ubicacion = Guid.NewGuid(),
            ID_Producto = ubicacion.ID_Producto,
            ID_Casillero = command.ID_Casillero_New,
            Cantidad = command.Cantidad,
            Fecha_Llegada = ubicacion.Fecha_Llegada,
            Fecha_Caducidad = ubicacion.Fecha_Caducidad,
            Confirmar_Guardado = ubicacion.Confirmar_Guardado
        };
        
        await _ubicacionRepository.UpdateUbicacionAsync(ubicacion);
        await _ubicacionRepository.AddUbicacionAsync(new_ubicacion);
        
        return new UbicacionResult(new_ubicacion);
    }
}
