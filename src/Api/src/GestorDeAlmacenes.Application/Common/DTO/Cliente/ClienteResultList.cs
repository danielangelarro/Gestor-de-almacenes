using GestorDeAlmacenes.Application.Entities;
using System.Collections.Generic;

namespace GestorDeAlmacenes.Application.DTO.Clientes
{
    public record ClienteResultList(ICollection<Cliente> clientes);
}