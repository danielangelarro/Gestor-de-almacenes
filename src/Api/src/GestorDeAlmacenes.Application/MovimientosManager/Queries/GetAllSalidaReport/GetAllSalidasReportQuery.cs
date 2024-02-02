using ErrorOr;
using MediatR;
using Aspose.Pdf;

namespace GestorDeAlmacenes.Application.Entradas.Query.GetAllSalidaReport;

public record GetAllSalidasReportQuery() : IRequest<ErrorOr<Document>>;
