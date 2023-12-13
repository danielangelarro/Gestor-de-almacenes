using GestorDeAlmacenes.Domain.Entities;

namespace GestorDeAlmacenes.Application.Entities;

public class Ubicacion
{
   public int ID_Producto { get; set; }
   public int ID_Casillero { get; set; }
   public int Cantidad { get; set; }

   // Relaciones
   public Producto Producto { get; set; }
   public Casillero Casillero { get; set; }
}