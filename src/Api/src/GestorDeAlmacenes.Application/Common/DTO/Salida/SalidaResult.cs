using GestorDeAlmacenes.Application.Entities;

namespace GestorDeAlmacenes.Application.DTO.Salidas
{
    public record SalidaResult(
        Movimientos salida, 
        ICollection<Ubicacion_Salida> ubicaciones
    );
}