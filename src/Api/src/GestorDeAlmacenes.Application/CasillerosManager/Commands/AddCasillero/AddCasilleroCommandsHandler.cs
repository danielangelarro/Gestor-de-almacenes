using GestorDeAlmacenes.Application.Common.Interfaces;
using GestorDeAlmacenes.Application.DTO.Casilleros;
using GestorDeAlmacenes.Application.Entities;
using GestorDeAlmacenes.Domain.Common.Errors;
using MediatR;
using ErrorOr;

namespace GestorDeAlmacenes.Application.Casilleros.Commands.Add;

public class AddCasilleroCommandsHandler : IRequestHandler<AddCasilleroCommands, ErrorOr<CasilleroResult>>
{
   private readonly ICasilleroRepository _casilleroRepository;

   public AddCasilleroCommandsHandler(ICasilleroRepository casilleroRepository)
   {
       _casilleroRepository = casilleroRepository;
   }

   public async Task<ErrorOr<CasilleroResult>> Handle(AddCasilleroCommands command, CancellationToken cancellationToken)
   {
       var casillero = new Casillero
       {
            ID_Casillero = Guid.NewGuid(),
            ID_Rack = command.ID_Rack,
            Area = command.Area,
            Peso_Maximo = command.Peso_Maximo,
            Alto = command.Alto,
            Ancho = command.Ancho,
            Largo = command.Largo,
            Unidad_Dimensiones = command.Unidad_Dimensiones
       };

       await _casilleroRepository.AddCasilleroAsync(casillero);
       
       return new CasilleroResult(casillero);
   }
}
