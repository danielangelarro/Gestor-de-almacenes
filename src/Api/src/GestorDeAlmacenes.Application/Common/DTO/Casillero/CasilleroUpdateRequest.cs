using System;

namespace GestorDeAlmacenes.Application.DTO.Casilleros
{
    public record CasilleroUpdateRequest(
        Guid ID_Casillero,
        string Pasillo
    );
}