using GestorDeAlmacenes.Application.Entities;
using System;

namespace GestorDeAlmacenes.Application.DTO.Product
{
    public record ProductConfirmUpload(
        Guid Ubicacion
    );
}