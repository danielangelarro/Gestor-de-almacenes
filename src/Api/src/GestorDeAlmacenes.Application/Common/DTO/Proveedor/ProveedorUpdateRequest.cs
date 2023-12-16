using System;

namespace GestorDeAlmacenes.Application.DTO.Proveedors
{
    public record ProveedorUpdateRequest(
        Guid ID_Proveedor,
        string Nombres,
        string Apellidos,
        string CI,
        string Telefono,
        string Correo,
        string Direccion
    );
}