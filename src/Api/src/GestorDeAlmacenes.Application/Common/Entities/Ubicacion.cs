using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using GestorDeAlmacenes.Domain.Entities;

namespace GestorDeAlmacenes.Application.Entities;

public class Ubicacion
{
   [Key]
   public Guid ID_Ubicacion { get; set; }
   
   public Guid ID_Producto { get; set; }
   public Guid ID_Casillero { get; set; }   
   public int Cantidad { get; set; }
   public DateTime Fecha_Llegada { get; set; }
   public DateTime Fecha_Caducidad { get; set; }
   public bool Confirmar_Guardado { get; set; }

   // Relaciones
   [ForeignKey("ID_Producto")]
   [JsonIgnore]
   public Producto Producto { get; set; }

   [ForeignKey("ID_Casillero")]
   [JsonIgnore]
   public Casillero Casillero { get; set; }
}