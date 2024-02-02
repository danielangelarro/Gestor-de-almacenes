using ErrorOr;
using GestorDeAlmacenes.Application.Common.Interfaces;
using GestorDeAlmacenes.Application.DTO.Entradas;
using MediatR;
using Aspose.Pdf;
using Aspose.Pdf.Annotations;
using Aspose.Pdf.Text;

namespace GestorDeAlmacenes.Application.Entradas.Query.GetAllRacksReport;

public class GetAllRacksReportQueryHandler : IRequestHandler<GetAllRacksReportQuery, ErrorOr<Document>>
{
    private readonly IRackRepository _rackRepository;
    private readonly IUbicacionRepository _ubicacionRepository;
    private readonly IProductoRepository _productoRepository;
    private readonly ICasilleroRepository _casilleroRepository;

    public GetAllRacksReportQueryHandler(
        IRackRepository rackRepository,
        IUbicacionRepository ubicacionRepository,
        IProductoRepository productoRepository,
        ICasilleroRepository casilleroRepository)
    {
        _rackRepository = rackRepository;
        _ubicacionRepository = ubicacionRepository;
        _productoRepository = productoRepository;
        _casilleroRepository = casilleroRepository;
    }

    public async Task<ErrorOr<Document>> Handle(GetAllRacksReportQuery query, CancellationToken cancellationToken)
    {
        var ubicaciones = await _ubicacionRepository.GetAllUbicacionesAsync();

        // // Crea una instancia de la clase de licencia
        // Aspose.Pdf.License license = new Aspose.Pdf.License();

        // // Aplica la licencia
        // license.SetLicense("Path_a_tu_archivo_de_licencia.lic");

        Document document = new Document();

        // Configurar los márgenes de la página
        document.PageInfo.Margin.Left = 50; // Reducir el margen izquierdo a 50 unidades
        document.PageInfo.Margin.Right = 50; // Reducir el margen izquierdo a 50 unidades

        // Crear la tabla
        Table table = new Table();
        table.ColumnAdjustment = ColumnAdjustment.AutoFitToWindow; // Ajustar la tabla a los límites de la hoja
        table.DefaultCellTextState.HorizontalAlignment = HorizontalAlignment.Center; // Centrar el contenido de las celdas
        table.DefaultCellTextState.FontSize = 8; // Centrar el contenido de las celdas
        table.Border = new BorderInfo(BorderSide.All, .5f, Color.FromRgb(System.Drawing.Color.LightGray));
        table.DefaultCellBorder = new BorderInfo(BorderSide.All, .5f, Color.FromRgb(System.Drawing.Color.LightGray));

        // Agregar las cabeceras de la tabla
        Row headerRow = table.Rows.Add();
        headerRow.Cells.Add("UBICACIÓN");
        headerRow.Cells.Add("PRODUCTO");
        // headerRow.Cells.Add("AUTORIZACIÓN");
        headerRow.Cells.Add("CANTIDAD");
        headerRow.Cells.Add("FECHA DE LLEGADA");
        headerRow.Cells.Add("FECHA DE CADUCIDAD");

        // Aquí puedes agregar las filas de la tabla con los datos de los productos
        // Por ejemplo:
        foreach (var ubicacion in ubicaciones)
        {
            if (ubicacion.Confirmar_Guardado)
            {
                continue;
            }

            var producto = await _productoRepository.GetProductoByIdAsync(ubicacion.ID_Producto);
            string productoName = producto.Nombre;

            var casillero = await _casilleroRepository.GetCasilleroByIdAsync(ubicacion.ID_Casillero);
            var rack = await _rackRepository.GetRackByIdAsync(casillero.ID_Rack);

            var x = (casillero.Index % rack.Columnas) + 1;
            var y = (casillero.Index / rack.Columnas) + 1;

            if (rack.Pasillo == "Wait")
            {
                continue;
            }

            Row row = table.Rows.Add();
            row.Cells.Add($"{rack.Pasillo} [{x}, {y}]");
            row.Cells.Add(productoName);
            // row.Cells.Add(ubicacion.Autorization);
            row.Cells.Add(ubicacion.Cantidad.ToString());
            row.Cells.Add(ubicacion.Fecha_Llegada.ToShortDateString());
            row.Cells.Add(ubicacion.Fecha_Caducidad.ToShortDateString());
        }

        Page page = document.Pages.Add();

        // Agregar el subtítulo con el nombre del documento
        TextFragment title = new TextFragment("Ubicacion de productos");
        title.TextState.HorizontalAlignment = HorizontalAlignment.Center; // Centrar el título
        page.Paragraphs.Add(title);
        page.Paragraphs.Add(new Aspose.Pdf.Text.TextFragment("\n\n"));

        // Agregar la tabla al documento
        page.Paragraphs.Add(table);

        // Agregar espacios para las firmas
        page.Paragraphs.Add(new Aspose.Pdf.Text.TextFragment("\n\nFirma del Proveedor: ________________"));
        page.Paragraphs.Add(new Aspose.Pdf.Text.TextFragment("\nFirma del Almacenero: ________________"));

        return document;
    }
}