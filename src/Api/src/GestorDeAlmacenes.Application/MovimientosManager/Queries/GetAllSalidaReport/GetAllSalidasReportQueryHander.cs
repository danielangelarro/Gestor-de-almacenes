using ErrorOr;
using GestorDeAlmacenes.Application.Common.Interfaces;
using GestorDeAlmacenes.Application.DTO.Entradas;
using MediatR;
using Aspose.Pdf;
using Aspose.Pdf.Annotations;
using Aspose.Pdf.Text;

namespace GestorDeAlmacenes.Application.Entradas.Query.GetAllSalidaReport;

public class GetAllSalidasReportQueryHandler : IRequestHandler<GetAllSalidasReportQuery, ErrorOr<Document>>
{
    private readonly IMovimientoRepository _repository;

    public GetAllSalidasReportQueryHandler(IMovimientoRepository salidaRepository)
    {
        _repository = salidaRepository;
    }

    public async Task<ErrorOr<Document>> Handle(GetAllSalidasReportQuery query, CancellationToken cancellationToken)
    {
        var salidas = await _repository.GetAllSalidasAsync();

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
        headerRow.Cells.Add("PRODUCTO");
        headerRow.Cells.Add("PROVEEDOR");
        headerRow.Cells.Add("AUTORIZACIÓN");
        headerRow.Cells.Add("CANTIDAD");
        headerRow.Cells.Add("PRECIO UNITARIO");
        headerRow.Cells.Add("PRECIO TOTAL");
        headerRow.Cells.Add("FECHA DE SALIDA");
        headerRow.Cells.Add("FECHA DE CADUCIDAD");

        // Aquí puedes agregar las filas de la tabla con los datos de los productos
        // Por ejemplo:
        foreach (var salida in salidas)
        {
            Row row = table.Rows.Add();
            row.Cells.Add(salida.Producto_Name);
            row.Cells.Add(salida.Cliente_Name);
            row.Cells.Add(salida.Autorization);
            row.Cells.Add(salida.Cantidad.ToString());
            row.Cells.Add("$" + salida.Precio_Unidad.ToString());
            row.Cells.Add("$" + (salida.Precio_Unidad * salida.Cantidad).ToString());
            row.Cells.Add(salida.Fecha.ToShortDateString());
            row.Cells.Add(salida.Fecha_Caducidad.ToShortDateString());
        }

        Page page = document.Pages.Add();

        // Agregar el subtítulo con el nombre del documento
        TextFragment title = new TextFragment("Salidas de productos");
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