using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using GestorDeAlmacenes.Domain.Entities;

namespace GestorDeAlmacenes.Application.Entities;

public class Ubicacion_Salida
{
    [Key]
    public Guid ID_Ubicacion_Salida { get; set; }
    public Guid ID_Ubicacion { get; set; }
    public Guid ID_Salida { get; set; }
    public string Pasillo { get; set; }
    public long Indice_Casillero { get; set; }

    // Relaciones
    [ForeignKey("ID_Ubicacion")]
    [JsonIgnore]
    public Ubicacion Ubicacion { get; set; }

    [ForeignKey("ID_Salida")]
    [JsonIgnore]
    public Movimientos Salida { get; set; }
}