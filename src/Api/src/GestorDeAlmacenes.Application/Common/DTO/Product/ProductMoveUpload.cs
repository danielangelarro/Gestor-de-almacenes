using GestorDeAlmacenes.Application.Entities;
using System;

namespace GestorDeAlmacenes.Application.DTO.Product
{
    public record ProductMoveUpload(
        Guid Ubicacion,
        Guid ID_Casillero_New,
        int Cantidad
    );
}