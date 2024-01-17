using System.Net.Http.Headers;
using GestorDeAlmacenes.Application.Common.Interfaces;
using GestorDeAlmacenes.Application.DTO.Racks;
using GestorDeAlmacenes.Application.Entities;
using GestorDeAlmacenes.Domain.Common.Errors;
using MediatR;
using ErrorOr;
using GestorDeAlmacenes.Application.Casilleros.Commands.Delete;
using GestorDeAlmacenes.Application.Casilleros.Query.GetCasilleroByRackId;

namespace GestorDeAlmacenes.Application.Racks.Commands.Delete;

public class DeleteRackCommandsHandler : IRequestHandler<DeleteRackCommands, ErrorOr<RackResult>>
{
   private readonly IRackRepository _rackRepository;
   private readonly IMediator _mediator;

    public DeleteRackCommandsHandler(IRackRepository rackRepository, IMediator mediator)
    {
        _rackRepository = rackRepository;
        _mediator = mediator;
    }

    public async Task<ErrorOr<RackResult>> Handle(DeleteRackCommands command, CancellationToken cancellationToken)
    {
        if (await _rackRepository.GetRackByIdAsync(command.Id) is not Rack rack)
        {
            return Errors.Rack.NotFound;
        }

        var casillero_command_by_rack = new GetCasilleroByIdRackQuery(rack.ID_Rack);
        var response = await _mediator.Send(casillero_command_by_rack);

        foreach (var casillero in response.Value.casilleros)
        {
            var casillero_command = new DeleteCasilleroCommands(
                casillero.ID_Casillero
            );

            await _mediator.Send(casillero_command);
        }

        await _rackRepository.DeleteRackAsync(rack);
       
        return new RackResult(rack);
    }
}
