using GestorDeAlmacenes.Application.Entities;
using System.Collections.Generic;

namespace GestorDeAlmacenes.Application.DTO.Racks
{
    public record RackResultList(ICollection<Rack> racks);
}