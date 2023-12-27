using System.ComponentModel.DataAnnotations;
using GestorDeAlmacenes.Domain.Entities;

namespace GestorDeAlmacenes.Application.Entities;

public class Rack
{
   [Key]
   public Guid ID_Rack { get; set; }
   public string Pasillo { get; set; }

   // Relaciones
   public ICollection<Casillero> Casilleros { get; set; }
}