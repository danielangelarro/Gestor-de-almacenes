using System;

namespace GestorDeAlmacenes.Application.DTO.Clientes
{
    public record ClienteUpdateRequest(
        Guid ID_Cliente,
        string Nombres,
        string Apellidos,
        string CI,
        string Telefono,
        string Correo,
        string Direccion
    );
}