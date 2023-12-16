using GestorDeAlmacenes.Application.Entities;
using System.Collections.Generic;

namespace GestorDeAlmacenes.Application.DTO.Mermas
{
    public record MermaResultList(ICollection<Merma> mermas);
}