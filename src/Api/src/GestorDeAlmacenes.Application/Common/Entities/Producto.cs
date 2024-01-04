using System.ComponentModel.DataAnnotations;
using GestorDeAlmacenes.Domain.Entities;

namespace GestorDeAlmacenes.Application.Entities;

public class Producto
{
   [Key]
   public Guid ID_Producto { get; set; }
   public string Nombre { get; set; }
   public string Descripcion { get; set; }
   public string Tipo { get; set; }
   public float Alto { get; set; }
   public float Ancho { get; set; }
   public float Largo { get; set; }
   public string Unidad_Dimensiones { get; set; }
   public float Peso { get; set; }
   public bool EnAlmacen { get; set; }

   // Relaciones
   public ICollection<Ubicacion> Ubicaciones { get; set; }
   public ICollection<Merma> Mermas { get; set; }
   public ICollection<Entrada> Entradas { get; set; }
   public ICollection<Salida> Salidas { get; set; }
}