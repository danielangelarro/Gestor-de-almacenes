using System;

namespace GestorDeAlmacenes.Application.DTO.Salidas
{
    public record SalidaUpdateRequest(
        Guid ID_Salida,
        Guid ID_Producto,
        Guid ID_Usuario,
        int Cantidad,
        DateTime Fecha
    );
}