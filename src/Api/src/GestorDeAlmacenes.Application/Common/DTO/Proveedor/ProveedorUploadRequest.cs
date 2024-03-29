using GestorDeAlmacenes.Application.Entities;
using System;

namespace GestorDeAlmacenes.Application.DTO.Proveedors
{
    public record ProveedorUploadRequest(
        string Nombres,
        string Apellidos,
        string CI,
        string Telefono,
        string Correo,
        string Direccion
    );
}