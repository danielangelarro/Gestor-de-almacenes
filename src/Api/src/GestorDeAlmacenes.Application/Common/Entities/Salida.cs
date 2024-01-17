using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using GestorDeAlmacenes.Domain.Entities;

namespace GestorDeAlmacenes.Application.Entities;

public class Salida : ITransaction
{
   public Guid ID_Salida { get; set; }
   public Guid ID_Producto { get; set; }
   public Guid ID_Usuario { get; set; }
   public string Autor { get; set; }
   public string Producto_Name { get; set; }
   public int Cantidad { get; set; }
   public DateTime Fecha { get; set; }

   // Relaciones
   [ForeignKey("ID_Producto")]
   [JsonIgnore]
   public Producto Producto { get; set; }

   [ForeignKey("ID_Usuario")]
   [JsonIgnore]
   public User Usuario { get; set; }
}