using GestorDeAlmacenes.Application.Entities;
using System;

namespace GestorDeAlmacenes.Application.DTO.Salidas
{
    public record SalidaUploadRequest(
        Guid ID_Salida,
        Guid ID_Producto,
        Guid ID_Usuario,
        int Cantidad,
        DateTime Fecha
    );
}