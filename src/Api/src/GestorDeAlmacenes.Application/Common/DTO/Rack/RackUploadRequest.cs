using GestorDeAlmacenes.Application.Entities;
using System;

namespace GestorDeAlmacenes.Application.DTO.Racks
{
    public record RackUploadRequest(
        Guid ID_Racko,
        string Pasillo
    );
}