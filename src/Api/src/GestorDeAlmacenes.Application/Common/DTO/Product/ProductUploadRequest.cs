using GestorDeAlmacenes.Application.Entities;
using System;

namespace GestorDeAlmacenes.Application.DTO.Product
{
    public record ProductUploadRequest(
        string Nombre,
        string Descripcion,
        float Precio_Total,
        float Precio_Unitario,
        string Tipo,
        float Alto,
        float Ancho,
        float Largo,
        string Unidad_Dimensiones,
        float Peso,
        bool EnAlmacen
    );
}