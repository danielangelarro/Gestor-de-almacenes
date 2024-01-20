using GestorDeAlmacenes.Application.Entities;
using GestorDeAlmacenes.Domain.Entities;
using System.Collections.Generic;

namespace GestorDeAlmacenes.Application.DTO.Entradas
{
    public record EntradaResultList(ICollection<Movimientos> entradas);
}