using GestorDeAlmacenes.Application.DTO.Product;
using GestorDeAlmacenes.Application.Entities;

namespace GestorDeAlmacenes.Application.DTO.Casilleros
{
    public record CasilleroResultInfo(
        Casillero casillero,
        ICollection<ResultUbicacion> productos,
        float capacidad_Peso,
        float capacidad_Volumen
    );
}