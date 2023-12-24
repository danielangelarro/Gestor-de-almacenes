using GestorDeAlmacenes.Application.Entities;
using System;

namespace GestorDeAlmacenes.Application.DTO.Racks
{
    public record RackUploadRequest(
        string Pasillo
    );
}