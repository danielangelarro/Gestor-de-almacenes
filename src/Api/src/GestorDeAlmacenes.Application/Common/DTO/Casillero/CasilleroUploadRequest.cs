using GestorDeAlmacenes.Application.Entities;
using System;

namespace GestorDeAlmacenes.Application.DTO.Casilleros
{
    public record CasilleroUploadRequest(
        Guid ID_Rack,
        float Area,
        float Peso_Maximo,
        float Alto,
        float Ancho,
        float Largo,
        string Unidad_Dimensiones
    );
}