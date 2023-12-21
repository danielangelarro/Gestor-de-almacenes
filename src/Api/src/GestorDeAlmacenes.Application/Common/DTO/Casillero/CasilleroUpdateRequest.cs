using System;

namespace GestorDeAlmacenes.Application.DTO.Casilleros
{
    public record CasilleroUpdateRequest(
        Guid ID_Casillero,
        float Area,
        float Peso_Maximo,
        float Alto,
        float Ancho,
        float Largo,
        string Unidad_Dimensiones
    );
}