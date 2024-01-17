using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace GestorDeAlmacenes.Application.Entities;

public class Merma
{
   [Key]
   public Guid ID_Merma { get; set; }
   public Guid ID_Producto { get; set; }
   
   public int Cantidad { get; set; }
   public DateTime Fecha_Caducidad { get; set; }
 
   // Relaciones
   [ForeignKey("ID_Producto")]
   [JsonIgnore]
   public Producto Producto { get; set; }
}