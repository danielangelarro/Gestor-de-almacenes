using GestorDeAlmacenes.Application.Common.Interfaces;
using GestorDeAlmacenes.Application.DTO.Salidas;
using GestorDeAlmacenes.Application.Entities;
using GestorDeAlmacenes.Domain.Common.Errors;
using MediatR;
using ErrorOr;

namespace GestorDeAlmacenes.Application.Salidas.Commands.Add;

public class AddSalidaCommandsHandler : IRequestHandler<AddSalidaCommands, ErrorOr<SalidaResult>>
{
   private readonly ISalidaRepository _salidaRepository;

   public AddSalidaCommandsHandler(ISalidaRepository salidaRepository)
   {
       _salidaRepository = salidaRepository;
   }

   public async Task<ErrorOr<SalidaResult>> Handle(AddSalidaCommands command, CancellationToken cancellationToken)
   {
       var salida = new Salida
       {
            ID_Salida = Guid.NewGuid(),
            ID_Producto = command.ID_Producto,
            ID_Usuario = command.ID_Usuario,
            Cantidad = command.Cantidad,
            Fecha = command.Fecha
       };

       await _salidaRepository.AddSalidaAsync(salida);
       
       return new SalidaResult(salida);
   }
}
