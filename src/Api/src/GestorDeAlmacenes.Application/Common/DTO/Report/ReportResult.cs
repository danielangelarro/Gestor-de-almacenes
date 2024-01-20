using GestorDeAlmacenes.Application.Entities;

namespace GestorDeAlmacenes.Application.DTO.Report
{
    public record ReportResult(
        float Ganancia_Semanal,
        float Ganancia_Mensual,
        float Ganancia_Last_Semanal,
        float Ganancia_Last_Mensual,
        float Ganancia_Anual,
        int Entradas_Mensuales,
        int Salidas_Mensuales,
        int Entradas_Last_Mensuales,
        int Salidas_Last_Mensuales,
        int Cantidad_Proveedores,
        int Cantidad_Clientes,
        int Tipos_Productos,
        ICollection<float> Total_Ganancias_Mensuales,
        ICollection<int> Total_Compras_Mensuales,
        ICollection<int> Total_Ventas_Mensuales
    );
}