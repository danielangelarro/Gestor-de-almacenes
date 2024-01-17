using GestorDeAlmacenes.Application.DTO.Racks;
using MediatR;
using ErrorOr;

namespace GestorDeAlmacenes.Application.Racks.Commands.Update;

public record UpdateRackCommands(
   Guid Id,
   string Pasillo,
   int Filas,
   int Columnas,
   float Peso_Maximo,
   float Alto,
   float Ancho,
   float Largo,
   string Unidad_Dimensiones
) : IRequest<ErrorOr<RackResult>>;
