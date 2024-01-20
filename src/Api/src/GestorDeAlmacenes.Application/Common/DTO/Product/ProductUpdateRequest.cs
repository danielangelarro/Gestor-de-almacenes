using System;

namespace GestorDeAlmacenes.Application.DTO.Product
{
    public record ProductUpdateRequest(
        Guid ID_Producto,
        string Nombre,
        string Descripcion,
        string Tipo,
        float Alto,
        float Ancho,
        float Largo,
        string Unidad_Dimensiones,
        float Peso,
        float Precio_Entrada,
        float Precio_Salida,
        bool EnAlmacen
    );
}