using System.Net.Http.Headers;
using GestorDeAlmacenes.Application.Common.Interfaces;
using GestorDeAlmacenes.Application.DTO.Racks;
using GestorDeAlmacenes.Application.Entities;
using GestorDeAlmacenes.Domain.Common.Errors;
using MediatR;
using ErrorOr;

namespace GestorDeAlmacenes.Application.Racks.Commands.Update;

public class UpdateRackCommandsHandler : IRequestHandler<UpdateRackCommands, ErrorOr<RackResult>>
{
   private readonly IRackRepository _rackRepository;

   public UpdateRackCommandsHandler(IRackRepository rackRepository)
   {
       _rackRepository = rackRepository;
   }

   public async Task<ErrorOr<RackResult>> Handle(UpdateRackCommands command, CancellationToken cancellationToken)
   {
        if (await _rackRepository.GetRackByIdAsync(command.Id) is not Rack rack)
        {
            return Errors.Rack.NotFound;
        }

        rack.Pasillo = command.Pasillo;

       await _rackRepository.UpdateRackAsync(rack);
       
       return new RackResult(rack);
   }
}
