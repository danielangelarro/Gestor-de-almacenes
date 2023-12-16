using GestorDeAlmacenes.Application.Entities;
using System.Collections.Generic;

namespace GestorDeAlmacenes.Application.DTO.Casilleros
{
    public record CasilleroResultList(ICollection<Casillero> casilleros);
}