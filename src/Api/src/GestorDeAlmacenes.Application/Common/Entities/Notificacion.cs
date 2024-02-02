using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Emit;
using System.Text.Json.Serialization;
using GestorDeAlmacenes.Domain.Entities;

namespace GestorDeAlmacenes.Application.Entities;

public class Notificacion : ITransaction
{
   [Key]
   public Guid ID_Notificacion { get; set; }
   public Guid ID_Usuario { get; set; }
   public string Description { get; set; }
   public string Tipo { get; set; }
   public DateTime Fecha { get; set; }

   // Relaciones

   [ForeignKey("ID_Usuario")]
   [JsonIgnore]
   public User User { get; set; }
}