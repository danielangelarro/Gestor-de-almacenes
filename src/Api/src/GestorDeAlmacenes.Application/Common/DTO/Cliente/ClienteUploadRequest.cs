using GestorDeAlmacenes.Application.Entities;
using System;

namespace GestorDeAlmacenes.Application.DTO.Clientes
{
    public record ClienteUploadRequest(
        Guid ID_Cliente,
        string Nombres,
        string Apellidos,
        string CI,
        string Telefono,
        string Correo,
        string Direccion
    );
}