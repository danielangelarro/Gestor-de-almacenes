using GestorDeAlmacenes.Application.Common.Interfaces;
using GestorDeAlmacenes.Application.DTO.Racks;
using GestorDeAlmacenes.Application.Entities;
using GestorDeAlmacenes.Domain.Common.Errors;
using MediatR;
using ErrorOr;

namespace GestorDeAlmacenes.Application.Racks.Commands.Add;

public class AddRackCommandsHandler : IRequestHandler<AddRackCommands, ErrorOr<RackResult>>
{
   private readonly IRackRepository _rackRepository;

   public AddRackCommandsHandler(IRackRepository rackRepository)
   {
       _rackRepository = rackRepository;
   }

   public async Task<ErrorOr<RackResult>> Handle(AddRackCommands command, CancellationToken cancellationToken)
   {
       var rack = new Rack
       {
            ID_Rack = Guid.NewGuid(),
            Pasillo = command.Pasillo
       };

       await _rackRepository.AddRackAsync(rack);
       
       return new RackResult(rack);
   }
}
