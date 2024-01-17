using System;

namespace GestorDeAlmacenes.Application.DTO.Racks
{
    public record RackUpdateRequest(
        Guid ID_Rack,
        string Pasillo,
        int Filas,
        int Columnas,
        float Peso_Maximo,
        float Alto,
        float Ancho,
        float Largo,
        string Unidad_Dimensiones
    );
}