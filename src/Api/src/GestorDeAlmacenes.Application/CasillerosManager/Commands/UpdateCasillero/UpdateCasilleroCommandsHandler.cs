using System.Net.Http.Headers;
using GestorDeAlmacenes.Application.Common.Interfaces;
using GestorDeAlmacenes.Application.DTO.Casilleros;
using GestorDeAlmacenes.Application.Entities;
using GestorDeAlmacenes.Domain.Common.Errors;
using MediatR;
using ErrorOr;

namespace GestorDeAlmacenes.Application.Casilleros.Commands.Update;

public class UpdateCasilleroCommandsHandler : IRequestHandler<UpdateCasilleroCommands, ErrorOr<CasilleroResult>>
{
   private readonly ICasilleroRepository _casilleroRepository;

   public UpdateCasilleroCommandsHandler(ICasilleroRepository casilleroRepository)
   {
       _casilleroRepository = casilleroRepository;
   }

   public async Task<ErrorOr<CasilleroResult>> Handle(UpdateCasilleroCommands command, CancellationToken cancellationToken)
   {
        if (await _casilleroRepository.GetCasilleroByIdAsync(command.ID_Casillero) is not Casillero casillero)
        {
            return Errors.Casillero.NotFound;
        }

        casillero.Area = command.Area;
        casillero.Peso_Maximo = command.Peso_Maximo;
        casillero.Alto = command.Alto;
        casillero.Ancho = command.Ancho;
        casillero.Largo = command.Largo;
        casillero.Unidad_Dimensiones = command.Unidad_Dimensiones;

       await _casilleroRepository.UpdateCasilleroAsync(casillero);
       
       return new CasilleroResult(casillero);
   }
}
