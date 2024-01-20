using GestorDeAlmacenes.Application.Entities;
using System.Collections.Generic;

namespace GestorDeAlmacenes.Application.DTO.Product
{
    public record ResultUbicacion(
        Guid ID_Ubicacion,
        Guid ID_Producto,
        Guid ID_Casillero,

        string Nombre,
        string Tipo,
        float Alto,
        float Largo,
        float Ancho,
        string Unidad_Dimensions,
        float Peso,
        int Cantidad,
        DateTime Fecha_Llegada,
        DateTime Fecha_Caducidad,
        bool Confirmar_Guardado
    );

    public record ProductResultUbicacionList(ICollection<ResultUbicacion> ubicaciones);
}