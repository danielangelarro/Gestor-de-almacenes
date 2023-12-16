using System;

namespace GestorDeAlmacenes.Application.DTO.Mermas
{
    public record MermaUpdateRequest(
        Guid ID_Merma,
        Guid ID_Producto,
        int Cantidad,
        DateTime Fecha_Caducidad
    );
}