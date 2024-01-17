using System;
using GestorDeAlmacenes.Application.Common.Interfaces;
using GestorDeAlmacenes.Application.DTO.Racks;
using GestorDeAlmacenes.Application.Entities;
using GestorDeAlmacenes.Domain.Common.Errors;
using MediatR;
using ErrorOr;
using GestorDeAlmacenes.Application.Casilleros.Commands.Add;
using GestorDeAlmacenes.Application.DTO.Casilleros;

namespace GestorDeAlmacenes.Application.Racks.Commands.Add;

public class AddRackCommandsHandler : IRequestHandler<AddRackCommands, ErrorOr<RackResult>>
{
   private readonly IRackRepository _rackRepository;
   private readonly ICasilleroRepository _casilleroRepository;

    public AddRackCommandsHandler(IRackRepository rackRepository, ICasilleroRepository casilleroRepository)
    {
        _rackRepository = rackRepository;
        _casilleroRepository = casilleroRepository;
    }

    public async Task<ErrorOr<RackResult>> Handle(AddRackCommands command, CancellationToken cancellationToken)
    {
        var rack = new Rack
        {
                ID_Rack = Guid.NewGuid(),
                Pasillo = command.Pasillo,
                Cantidad_Casillas = command.Filas * command.Columnas,
                Filas = command.Filas,
                Columnas = command.Columnas,
                Peso_Maximo = command.Peso_Maximo,
                Alto = command.Alto,
                Ancho = command.Ancho,
                Largo = command.Largo,
                Unidad_Dimensiones = command.Unidad_Dimensiones,
                Type = "rack"
        };

        await _rackRepository.AddRackAsync(rack);

        for (int i = 0; i < rack.Cantidad_Casillas; i++)
        {
            var casillero = new Casillero
            {
                ID_Casillero = Guid.NewGuid(),
                ID_Rack = rack.ID_Rack,
                Index = i + 1,
                Area = command.Largo * command.Ancho,
                Peso_Maximo = command.Peso_Maximo,
                Alto = command.Alto,
                Ancho = command.Ancho,
                Largo = command.Largo,
                Unidad_Dimensiones = command.Unidad_Dimensiones
            };

            await _casilleroRepository.AddCasilleroAsync(casillero);
        }
        
        return new RackResult(rack);
    }
}
