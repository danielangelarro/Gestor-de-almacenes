using GestorDeAlmacenes.Domain.Entities;

namespace GestorDeAlmacenes.Application.Entities;

public class Entrada : ITransaction
{
   public Guid ID_Entrada { get; set; }
   public Guid ID_Producto { get; set; }
   public Guid ID_Usuario { get; set; }
   public int Cantidad { get; set; }
   public DateTime Fecha { get; set; }

   // Relaciones
   public Producto Producto { get; set; }
   public User Usuario { get; set; }
}