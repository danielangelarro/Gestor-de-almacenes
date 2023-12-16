using MediatR;
using ErrorOr;
using GestorDeAlmacenes.Application.DTO.Casilleros;

namespace GestorDeAlmacenes.Application.Casilleros.Commands.Add;

public record AddCasilleroCommands(
   Guid ID_Rack,
   float Area,
   float Peso_Maximo,
   float Alto,
   float Ancho,
   float Largo,
   string Unidad_Dimensiones
) : IRequest<ErrorOr<CasilleroResult>>;

