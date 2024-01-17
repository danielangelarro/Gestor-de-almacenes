using GestorDeAlmacenes.Application.Entities;
using System;

namespace GestorDeAlmacenes.Application.DTO.Racks
{
    public record RackUploadRequest(
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