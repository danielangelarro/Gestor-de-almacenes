using GestorDeAlmacenes.Application.Entities;
using System.Collections.Generic;

namespace GestorDeAlmacenes.Application.DTO.Entradas
{
    public record EntradaResultList(ICollection<Entrada> entradas);
}