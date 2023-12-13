using GestorDeAlmacenes.Application.Entities;
using System;

namespace GestorDeAlmacenes.Application.DTO.Product
{
    public record ProductUploadRequest(
        Guid ID_Producto,
        string Nombre,
        string Descripcion,
        float Precio_Total,
        float Precio_Unitario,
        int Cantidad,
        string Tipo,
        float Alto,
        float Ancho,
        float Largo,
        string Unidad_Dimensiones,
        float Peso,
        DateTime Fecha_Llegada,
        DateTime Fecha_Caducidad,
        bool EnAlmacen
    );
}