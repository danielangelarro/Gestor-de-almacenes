using GestorDeAlmacenes.Domain.Entities;

namespace GestorDeAlmacenes.Application.Entities;

public class Casillero
{
   public Guid ID_Casillero { get; set; }
   public Guid ID_Rack { get; set; }
   public float Area { get; set; }
   public float Peso_Maximo { get; set; }
   public float Alto { get; set; }
   public float Ancho { get; set; }
   public float Largo { get; set; }
   public string Unidad_Dimensiones { get; set; }

   // Relaciones
   public Rack Rack { get; set; }
   public ICollection<Ubicacion> Ubicaciones { get; set; }
}
