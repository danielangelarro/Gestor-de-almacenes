using GestorDeAlmacenes.Application.Entities;
using System;

namespace GestorDeAlmacenes.Application.DTO.Casilleros
{
    public record CasilleroUploadRequest(
        Guid ID_Casilleroo,
        string Pasillo
    );
}