using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using GestorDeAlmacenes.Domain.Entities;

namespace GestorDeAlmacenes.Application.Entities;

public class Casillero
{
   [Key]
   public Guid ID_Casillero { get; set; }
   public Guid ID_Rack { get; set; }
   public long Index { get; set; }
   public float Area { get; set; }
   public float Peso_Maximo { get; set; }
   public float Alto { get; set; }
   public float Ancho { get; set; }
   public float Largo { get; set; }
   public string Unidad_Dimensiones { get; set; }

   // Relaciones
   [ForeignKey("ID_Rack")]
   [JsonIgnore]
   public Rack Rack { get; set; }
   public ICollection<Ubicacion> Ubicaciones { get; set; }
}
