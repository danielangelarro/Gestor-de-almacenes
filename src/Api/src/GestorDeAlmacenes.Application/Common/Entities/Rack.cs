using System.ComponentModel.DataAnnotations;
using GestorDeAlmacenes.Domain.Entities;

namespace GestorDeAlmacenes.Application.Entities;

public class Rack
{
   [Key]
   public Guid ID_Rack { get; set; }
   public string Pasillo { get; set; }
   public int Cantidad_Casillas { get; set; }
   public int Filas { get; set; }
   public int Columnas { get; set; }
   public float Peso_Maximo { get; set; }
   public float Alto { get; set; }
   public float Ancho { get; set; }
   public float Largo { get; set; }
   public string Unidad_Dimensiones { get; set; }
   public string Type { get; set; }

   // Relaciones
   public ICollection<Casillero> Casilleros { get; set; }
}