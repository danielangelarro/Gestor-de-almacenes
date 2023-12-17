using GestorDeAlmacenes.Application.Entities;
using GestorDeAlmacenes.Domain.Entities;
using System.Collections.Generic;

namespace GestorDeAlmacenes.Application.DTO.EntradaAndSalidas
{
    public record EntradaAndSalidaResultList(ICollection<ITransaction> entrada_salida);
}