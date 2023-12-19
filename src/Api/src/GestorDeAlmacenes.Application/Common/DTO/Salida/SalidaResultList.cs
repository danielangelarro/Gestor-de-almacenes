using GestorDeAlmacenes.Application.Entities;
using System.Collections.Generic;

namespace GestorDeAlmacenes.Application.DTO.Salidas
{
    public record SalidaResultList(ICollection<Salida> salidas);
}