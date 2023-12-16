using System.Net.Http.Headers;
using GestorDeAlmacenes.Application.Common.Interfaces;
using GestorDeAlmacenes.Application.DTO.Racks;
using GestorDeAlmacenes.Application.Entities;
using GestorDeAlmacenes.Domain.Common.Errors;
using MediatR;
using ErrorOr;

namespace GestorDeAlmacenes.Application.Racks.Commands.Delete;

public class DeleteRackCommandsHandler : IRequestHandler<DeleteRackCommands, ErrorOr<RackResult>>
{
   private readonly IRackRepository _rackRepository;

   public DeleteRackCommandsHandler(IRackRepository rackRepository)
   {
       _rackRepository = rackRepository;
   }

   public async Task<ErrorOr<RackResult>> Handle(DeleteRackCommands command, CancellationToken cancellationToken)
   {
        if (await _rackRepository.GetRackByIdAsync(command.Id) is not Rack rack)
        {
            return Errors.Rack.NotFound;
        }

       await _rackRepository.DeleteRackAsync(rack);
       
       return new RackResult(rack);
   }
}
