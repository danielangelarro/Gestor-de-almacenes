using GestorDeAlmacenes.Application.Common.Interfaces;
using GestorDeAlmacenes.Application.DTO.Mermas;
using GestorDeAlmacenes.Application.Entities;
using GestorDeAlmacenes.Domain.Common.Errors;
using MediatR;
using ErrorOr;

namespace GestorDeAlmacenes.Application.Mermas.Commands.Add;

public class AddMermaCommandsHandler : IRequestHandler<AddMermaCommands, ErrorOr<MermaResult>>
{
   private readonly IMermaRepository _mermaRepository;

   public AddMermaCommandsHandler(IMermaRepository mermaRepository)
   {
       _mermaRepository = mermaRepository;
   }

   public async Task<ErrorOr<MermaResult>> Handle(AddMermaCommands command, CancellationToken cancellationToken)
   {
       var merma = new Merma
       {
            ID_Merma = Guid.NewGuid(),
            ID_Producto = command.ID_Producto,
            Cantidad = command.Cantidad,
            Fecha_Caducidad = command.Fecha_Caducidad
       };

       await _mermaRepository.AddMermaAsync(merma);
       
       return new MermaResult(merma);
   }
}
