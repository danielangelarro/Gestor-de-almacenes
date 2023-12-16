using System;

namespace GestorDeAlmacenes.Application.DTO.Racks
{
    public record RackUpdateRequest(
        Guid ID_Rack,
        string Pasillo
    );
}