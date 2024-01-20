using System;
using GestorDeAlmacenes.Application.Common.Interfaces;
using GestorDeAlmacenes.Application.DTO.Product;
using GestorDeAlmacenes.Application.Entities;
using GestorDeAlmacenes.Domain.Common.Errors;
using MediatR;
using ErrorOr;

namespace GestorDeAlmacenes.Application.Product.Commands.Confirm;

public class ConfirmProductCommandsHandler : IRequestHandler<ConfirmProductCommands, ErrorOr<UbicacionResult>>
{
   private readonly IUbicacionRepository _ubicacionRepository;

    public ConfirmProductCommandsHandler(IUbicacionRepository ubicacionRepository)
    {
        _ubicacionRepository = ubicacionRepository;
    }

    public async Task<ErrorOr<UbicacionResult>> Handle(ConfirmProductCommands command, CancellationToken cancellationToken)
    {
        if (await _ubicacionRepository.GetUbicacionByIdAsync(command.Ubicacion) is not Ubicacion ubicacion)
        {
            return Errors.Ubicacion.NotFound;
        }

        ubicacion.Confirmar_Guardado = true;
        await _ubicacionRepository.UpdateUbicacionAsync(ubicacion);
        
        return new UbicacionResult(ubicacion);
    }
}
