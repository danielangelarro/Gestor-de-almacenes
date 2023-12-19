using GestorDeAlmacenes.Application.Entities;
using GestorDeAlmacenes.Domain.Entities;
using System.Collections.Generic;

namespace GestorDeAlmacenes.Application.DTO.EntradaAndSalidas
{
    public record UploadSalidaRequest(
        Guid ID_Producto,
        Guid ID_Usuario,
        int Cantidad,
        DateTime Fecha
    );
}