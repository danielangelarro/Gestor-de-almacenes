using GestorDeAlmacenes.Application.Entities;
using System.Collections.Generic;

namespace GestorDeAlmacenes.Application.DTO.Product
{
    public record ProductResultList(ICollection<Producto> productos);
}