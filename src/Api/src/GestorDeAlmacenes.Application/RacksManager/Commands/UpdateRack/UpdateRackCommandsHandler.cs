using System.Net.Http.Headers;
using GestorDeAlmacenes.Application.Common.Interfaces;
using GestorDeAlmacenes.Application.DTO.Racks;
using GestorDeAlmacenes.Application.Entities;
using GestorDeAlmacenes.Domain.Common.Errors;
using MediatR;
using ErrorOr;
using GestorDeAlmacenes.Application.Casilleros.Commands.Update;
using GestorDeAlmacenes.Application.Casilleros.Query.GetAllCasilleros;
using GestorDeAlmacenes.Application.Casilleros.Query.GetCasilleroById;
using GestorDeAlmacenes.Application.Casilleros.Query.GetCasilleroByRackId;
using FluentValidation;

namespace GestorDeAlmacenes.Application.Racks.Commands.Update;

public class UpdateRackCommandsHandler : IRequestHandler<UpdateRackCommands, ErrorOr<RackResult>>
{
    private readonly IRackRepository _rackRepository;
    private readonly IMediator _mediator;

    public UpdateRackCommandsHandler(IRackRepository rackRepository, IMediator mediator)
    {
        _rackRepository = rackRepository;
        _mediator = mediator;
    }

    public async Task<ErrorOr<RackResult>> Handle(UpdateRackCommands command, CancellationToken cancellationToken)
    {
        if (await _rackRepository.GetRackByIdAsync(command.Id) is not Rack rack)
        {
            return Errors.Rack.NotFound;
        }

        rack.Pasillo = command.Pasillo;
        rack.Cantidad_Casillas = command.Filas * command.Columnas;
        rack.Filas = command.Filas;
        rack.Columnas = command.Columnas;
        rack.Peso_Maximo = command.Peso_Maximo;
        rack.Alto = command.Alto;
        rack.Ancho = command.Ancho;
        rack.Largo = command.Largo;
        rack.Unidad_Dimensiones = command.Unidad_Dimensiones;

        await _rackRepository.UpdateRackAsync(rack);

        var casillero_command_by_rack = new GetCasilleroByIdRackQuery(rack.ID_Rack);
        var response = await _mediator.Send(casillero_command_by_rack);

        foreach (var casillero in response.Value.casilleros)
        {
            var casillero_command = new UpdateCasilleroCommands(
                casillero.ID_Casillero,
                command.Largo * command.Ancho,
                command.Peso_Maximo,
                command.Alto,
                command.Ancho,
                command.Largo,
                command.Unidad_Dimensiones
            );

            await _mediator.Send(casillero_command);
        }
       
        return new RackResult(rack);
   }
}
