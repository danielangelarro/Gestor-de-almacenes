using System.ComponentModel.DataAnnotations;

namespace GestorDeAlmacenes.Application.Entities;

public class Merma
{
   [Key]
   public Guid ID_Merma { get; set; }
   public Guid ID_Producto { get; set; }
   
   public int Cantidad { get; set; }
   public DateTime Fecha_Caducidad { get; set; }

   // Relaciones
   public Producto Producto { get; set; }
}