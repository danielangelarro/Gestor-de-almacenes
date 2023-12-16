using GestorDeAlmacenes.Application.DTO.Casilleros;
using MediatR;
using ErrorOr;

namespace GestorDeAlmacenes.Application.Casilleros.Commands.Update;

public record UpdateCasilleroCommands(
   Guid ID_Casillero,
   float Area,
   float Peso_Maximo,
   float Alto,
   float Ancho,
   float Largo,
   string Unidad_Dimensiones
) : IRequest<ErrorOr<CasilleroResult>>;
