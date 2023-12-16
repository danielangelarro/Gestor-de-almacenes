using GestorDeAlmacenes.Application.Entities;
using System.Collections.Generic;

namespace GestorDeAlmacenes.Application.DTO.Proveedors
{
    public record ProveedorResultList(ICollection<Proveedor> proveedors);
}