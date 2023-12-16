using System.Net.Http.Headers;
using GestorDeAlmacenes.Application.Common.Interfaces;
using GestorDeAlmacenes.Application.DTO.Casilleros;
using GestorDeAlmacenes.Application.Entities;
using GestorDeAlmacenes.Domain.Common.Errors;
using MediatR;
using ErrorOr;

namespace GestorDeAlmacenes.Application.Casilleros.Commands.Delete;

public class DeleteCasilleroCommandsHandler : IRequestHandler<DeleteCasilleroCommands, ErrorOr<CasilleroResult>>
{
   private readonly ICasilleroRepository _casilleroRepository;

   public DeleteCasilleroCommandsHandler(ICasilleroRepository casilleroRepository)
   {
       _casilleroRepository = casilleroRepository;
   }

   public async Task<ErrorOr<CasilleroResult>> Handle(DeleteCasilleroCommands command, CancellationToken cancellationToken)
   {
        if (await _casilleroRepository.GetCasilleroByIdAsync(command.Id_Casillero) is not Casillero casillero)
        {
            return Errors.Casillero.NotFound;
        }

       await _casilleroRepository.DeleteCasilleroAsync(casillero);
       
       return new CasilleroResult(casillero);
   }
}
