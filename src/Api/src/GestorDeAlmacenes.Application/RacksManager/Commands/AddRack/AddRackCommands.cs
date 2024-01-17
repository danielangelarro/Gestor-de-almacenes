using MediatR;
using ErrorOr;
using GestorDeAlmacenes.Application.DTO.Racks;

namespace GestorDeAlmacenes.Application.Racks.Commands.Add;

public record AddRackCommands(
   string Pasillo,
   int Filas,
   int Columnas,
   float Peso_Maximo,
   float Alto,
   float Ancho,
   float Largo,
   string Unidad_Dimensiones
) : IRequest<ErrorOr<RackResult>>;

