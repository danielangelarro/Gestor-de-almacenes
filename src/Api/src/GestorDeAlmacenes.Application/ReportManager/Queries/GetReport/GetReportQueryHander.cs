using ErrorOr;
using GestorDeAlmacenes.Application.Common.Interfaces;
using GestorDeAlmacenes.Application.DTO.Racks;
using GestorDeAlmacenes.Application.DTO.Report;
using GestorDeAlmacenes.Application.Racks.Query.GetReport;
using MediatR;

namespace GestorDeAlmacenes.Application.Racks.Query.GetAllRacks;

public class GetReportQueryHandler : IRequestHandler<GetReportQuery, ErrorOr<ReportResult>>
{
    private readonly IMovimientoRepository _repository;
    private readonly IProveedorRepository _proveedorRepository;
    private readonly IClienteRepository _clienteRepository;
    private readonly IProductoRepository _productoRepository;

    public GetReportQueryHandler(
        IMovimientoRepository rackoRepository, 
        IProveedorRepository proveedorRepository, 
        IClienteRepository clienteRepository, 
        IProductoRepository productoRepository)
    {
        _repository = rackoRepository;
        _proveedorRepository = proveedorRepository;
        _clienteRepository = clienteRepository;
        _productoRepository = productoRepository;
    }

    public async Task<ErrorOr<ReportResult>> Handle(GetReportQuery query, CancellationToken cancellationToken)
    {
        var Ganancia_Semanal = await _repository.GetGananciaSemanal();
        var Ganancia_Mensual = await _repository.GetGananciaMensual();
        var Ganancia_Last_Semanal = await _repository.GetGananciaLastSemanal();
        var Ganancia_Last_Mensual = await _repository.GetGananciaLastMensual();
        
        
        var Entradas_Mensuales = await _repository.GetEntradaMensual();
        var Salidas_Mensuales = await _repository.GetSalidaMensual();
        var Entradas_Last_Mensuales = await _repository.GetEntradaLastMensual();
        var Salidas_Last_Mensuales = await _repository.GetSalidaLastMensual();


        var Ganancia_Anual = await _repository.GetGananciaAnual();
        var Cantidad_Proveedores = await _proveedorRepository.GetProveedorCountAsync();
        var Cantidad_Clientes = await _clienteRepository.GetClienteCountAsync();
        var Tipos_Productos = await _productoRepository.GetProductoCountAsync();

        var Total_Ganancias_Mensuales = await _repository.GetAllGananciasMensualAsync();
        var Total_Compras_Mensuales = await _repository.GetAllEntradasMensualAsync();
        var Total_Ventas_Mensuales = await _repository.GetAllSalidasMensualAsync();

        return new ReportResult(
            Ganancia_Semanal: Ganancia_Semanal,
            Ganancia_Mensual: Ganancia_Mensual,
            Ganancia_Last_Semanal: Ganancia_Last_Semanal,
            Ganancia_Last_Mensual: Ganancia_Last_Mensual,
            Ganancia_Anual: Ganancia_Anual,
            Entradas_Mensuales: Entradas_Mensuales,
            Salidas_Mensuales: Salidas_Mensuales,
            Entradas_Last_Mensuales: Entradas_Last_Mensuales,
            Salidas_Last_Mensuales: Salidas_Last_Mensuales,
            Cantidad_Proveedores: Cantidad_Proveedores,
            Cantidad_Clientes: Cantidad_Clientes,
            Tipos_Productos: Tipos_Productos,
            Total_Ganancias_Mensuales: Total_Ganancias_Mensuales,
            Total_Compras_Mensuales: Total_Compras_Mensuales,
            Total_Ventas_Mensuales: Total_Ventas_Mensuales
        );
    }
}