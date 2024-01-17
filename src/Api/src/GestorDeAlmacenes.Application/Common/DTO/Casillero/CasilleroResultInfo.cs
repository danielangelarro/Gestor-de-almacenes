using GestorDeAlmacenes.Application.Entities;

namespace GestorDeAlmacenes.Application.DTO.Casilleros
{
    public record CasilleroResultInfo(
        Casillero casillero,
        IEnumerable<Producto> productos,
        float capacidad_Peso,
        float capacidad_Volumen
    );
}