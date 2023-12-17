using System;

namespace GestorDeAlmacenes.Application.DTO.Entradas
{
    public record EntradaUpdateRequest(
        Guid ID_Entrada,
        Guid ID_Producto,
        Guid ID_Usuario,
        int Cantidad,
        DateTime Fecha
    );
}