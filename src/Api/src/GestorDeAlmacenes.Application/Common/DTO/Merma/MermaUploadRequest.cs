using System;

namespace GestorDeAlmacenes.Application.DTO.Mermas
{
    public record MermaUploadRequest(
        Guid ID_Merma,
        Guid ID_Producto,
        int Cantidad,
        string Descripcion,
        DateTime Fecha_Caducidad
    );
}