using System.Data;
using GestorDeAlmacenes.Application.Common.Interfaces;
using GestorDeAlmacenes.Application.DTO.Entradas;
using GestorDeAlmacenes.Application.Entities;
using GestorDeAlmacenes.Domain.Common.Errors;
using MediatR;
using ErrorOr;

namespace GestorDeAlmacenes.Application.Entradas.Commands.Add;

public class AddEntradaCommandsHandler : IRequestHandler<AddEntradaCommands, ErrorOr<EntradaResult>>
{
   private readonly IEntradaRepository _entradaRepository;

   public AddEntradaCommandsHandler(IEntradaRepository entradaRepository)
   {
       _entradaRepository = entradaRepository;
   }

   public async Task<ErrorOr<EntradaResult>> Handle(AddEntradaCommands command, CancellationToken cancellationToken)
   {
       var entrada = new Entrada
       {
            ID_Entrada = Guid.NewGuid(),
            ID_Producto = command.ID_Producto,
            ID_Usuario = command.ID_Usuario,
            Cantidad = command.Cantidad,
            Fecha = command.Fecha
       };

       await _entradaRepository.AddEntradaAsync(entrada);
       
       return new EntradaResult(entrada);
   }
}
